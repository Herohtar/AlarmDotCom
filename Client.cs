using AlarmDotCom.JsonObjects;
using AlarmDotCom.JsonObjects.AvailableSystemItems;
using AlarmDotCom.JsonObjects.Systems;
using AlarmDotCom.JsonObjects.TemperatureSensorInfo;
using AlarmDotCom.JsonObjects.ThermostatInfo;
using HtmlAgilityPack;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AlarmDotCom
{
    /// <summary>
    /// Alarm.com doesn't provide a public API. This class allows you to log in and obtain a valid session for making JSON requests
    /// </summary>
    public class Client
    {
        private string un;
        private string pw;

        private const string rootUrl = @"https://www.alarm.com";
        private const string initialPageUrl = @"https://www.alarm.com/login.aspx";
        private const string loginFormUrl = @"https://www.alarm.com/web/Default.aspx";
        private const string keepAliveUrl = @"https://www.alarm.com/web/KeepAlive.aspx";
        private const string availableSystemItemsUrl = @"https://www.alarm.com/web/api/systems/availableSystemItems";
        private const string systemsUrl = @"https://www.alarm.com/web/api/systems/systems/";
        private const string thermostatsUrl = @"https://www.alarm.com/web/api/devices/thermostats/";
        private const string temperatureSensorsUrl = @"https://www.alarm.com/web/api/devices/remoteTemperatureSensors/";

        private const string userAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:55.0) Gecko/20100101 Firefox/55.0"; // An actual user agent string so our request looks like it's from a real browser

        private readonly AlarmDotComWebClient client = new AlarmDotComWebClient() { UserAgent = userAgent };

        public Client()
        {
            Log.Debug("AlarmDotCom Client created");
        }

        public bool Login(string username, string password)
        {
            un = username;
            pw = password;

            Log.Information("Attempting to login as {Username}", un);

            var success = false;
            try
            {
                var loginData = new NameValueCollection();
                var pageHtml = new HtmlDocument();

                // Load the first page in order to pull the ASP states/keys so our login request looks legit
                Log.Debug("Loading initial page {InitialPage}", initialPageUrl);
                var initialPageHtml = client.DownloadString(initialPageUrl);

                // Parse the response and create the login headers
                Log.Debug("Parsing HTML response");
                pageHtml.LoadHtml(initialPageHtml);
                // We need all the hidden ASP.NET state/event values. Grab everything that starts with double underscores just to make sure we get everything
                pageHtml.DocumentNode.Descendants("input").Where(i => i.Id.StartsWith("__")).ToList().ForEach(i => loginData.Add(i.Id, i.GetAttributeValue("value", string.Empty)));
                loginData.Add("IsFromNewSite", "1"); // Not sure what this does exactly, but it seems necessary to include it
                loginData.Add("JavaScriptTest", "1"); // Lie and say we support JavaScript
                loginData.Add("ctl00$ContentPlaceHolder1$loginform$txtUserName", un); // Username
                loginData.Add("txtPassword", pw.ToString()); // Password

                // Submit the login form
                Log.Debug("Submitting login form {LoginUrl}", loginFormUrl);
                client.Headers.Set(HttpRequestHeader.Referer, initialPageUrl);
                client.UploadValues(loginFormUrl, loginData);

                // Check the login status
                var loggedIn = client.CookieContainer.GetCookies(new Uri(rootUrl))["loggedInAsSubscriber"]?.Value;
                Log.Debug("loggedInAsSubscriber = {LoggedIn}", loggedIn);

                if ((loggedIn != null) && loggedIn.Equals("1"))
                {
                    success = true;
                    Log.Information("Login successful");
                }
                else
                {
                    Log.Error("Login failed");
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "Login failed");
            }

            return success;
        }

        public bool KeepAlive()
        {
            Log.Information("Sending keepalive");

            var success = false;
            try
            {
                Log.Debug("Posting keepalive to {KeepAliveUrl}", keepAliveUrl);
                var response = KeepAliveResponse.FromJson(client.UploadString(keepAliveUrl, $"timestamp={DateTimeOffset.Now.ToUnixTimeMilliseconds()}"));
                if (response.Status.Equals("Keep Alive", StringComparison.OrdinalIgnoreCase))
                {
                    success = true;
                    Log.Debug("Keepalive successful");
                }
                else
                {
                    Log.Error("Unrecognized keepalive status: {Status}", response.Status);
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = KeepAliveResponse.FromJson(new StreamReader(e.Response.GetResponseStream()).ReadToEnd());
                    if (response.Status.Equals("Session Expired", StringComparison.OrdinalIgnoreCase))
                    {
                        Log.Error("Keepalive failed: {Status}", response.Status);
                        success = Login(un, pw);
                    }
                    else
                    {
                        Log.Error("Unrecognized keepalive status: {Status}", response.Status);
                    }
                }
                else
                {
                    Log.Error(e, "Keepalive failed");
                }
            }

            return success;
        }

        private async Task<string> getJsonData(string requestUrl)
        {
            string response = null;
            var success = false;
            do
            {
                try
                {
                    Log.Debug("Requesting {Url}", requestUrl);
                    response = await client.DownloadStringTaskAsync(requestUrl);
                    success = true;
                    Log.Debug("Got {Data}", response);
                }
                catch (WebException e)
                {
                    Log.Error(e, "Request failed");
                    Login(un, pw);
                }
            } while (!success);

            return response;
        }

        public List<SystemItemData> GetAvailableSystems()
        {
            Log.Information("Getting available system items");

            var json = getJsonData(availableSystemItemsUrl);

            var availableSystemItems = AvailableSystemItems.FromJson(json);

            return availableSystemItems.Data;
        }

        public SystemData GetSystemData(SystemItemData systemItem)
        {
            Log.Information("Getting information for {SystemName} system", systemItem.Attributes.Name);
            Log.Debug("Requesting information for system ID {SystemId}", systemItem.Id);

            var requestUrl = systemsUrl + systemItem.Id;

            var json = getJsonData(requestUrl);

            var system = Systems.FromJson(json);

            return system.Data;
        }

        public ThermostatData GetThermostatData(string thermostatId)
        {
            Log.Information("Getting thermostat info");
            Log.Debug("Requesting information for thermostat ID {ThermostatId}", thermostatId);

            var requestUrl = thermostatsUrl + thermostatId;

            var json = getJsonData(requestUrl);

            var thermostat = ThermostatInfo.FromJson(json);

            return thermostat.Data;
        }

        public TemperatureSensorData GetTemperatureSensorData(string temperatureSensorId)
        {
            Log.Information("Getting temperature sensor info");
            Log.Debug("Requesting information for temperature sensor ID {TemperatureSensorId}", temperatureSensorId);

            var requestUrl = temperatureSensorsUrl + temperatureSensorId;

            var json = getJsonData(requestUrl);

            var temperatureSensor = TemperatureSensorInfo.FromJson(json);

            return temperatureSensor.Data;
        }
    }
}
