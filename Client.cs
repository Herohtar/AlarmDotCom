using AlarmDotCom.JsonObjects;
using AlarmDotCom.JsonObjects.AvailableSystemItems;
using AlarmDotCom.JsonObjects.Systems;
using AlarmDotCom.JsonObjects.TemperatureSensorInfo;
using AlarmDotCom.JsonObjects.ThermostatInfo;
using HtmlAgilityPack;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        private readonly CookieContainer cookieContainer = new CookieContainer();
        private readonly HttpClientHandler handler = new HttpClientHandler();
        private readonly HttpClient httpClient;

        public Client()
        {
            Log.Debug("AlarmDotCom Client created");
            handler.CookieContainer = cookieContainer;
            httpClient = new HttpClient(handler, true);
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
        }

        public async Task<bool> Login(string username, string password)
        {
            un = username;
            pw = password;

            Log.Information("Attempting to login as {Username}", un);

            var success = false;
            try
            {
                // Load the first page in order to pull the ASP states/keys so our login request looks legit
                Log.Debug("Loading initial page {InitialPage}", initialPageUrl);
                var response = await httpClient.GetAsync(initialPageUrl).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var initialPageHtml = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Parse the response and create the login headers
                Log.Debug("Parsing HTML response");
                var pageHtml = new HtmlDocument();
                pageHtml.LoadHtml(initialPageHtml);

                // We need all the hidden ASP.NET state/event values. Grab everything that starts with double underscores just to make sure we get everything
                var formData = new MultipartFormDataContent();
                foreach (var item in pageHtml.DocumentNode.Descendants("input").Where(i => i.Id.StartsWith("__")))
                {
                    formData.Add(new StringContent(item.GetAttributeValue("value", string.Empty)), item.Id);
                }
                formData.Add(new StringContent("1"), "IsFromNewSite"); // Not sure what this does exactly, but it seems necessary to include it
                formData.Add(new StringContent("1"), "JavaScriptTest"); // Lie and say we support JavaScript
                formData.Add(new StringContent(un), "ctl00$ContentPlaceHolder1$loginform$txtUserName"); // Username
                formData.Add(new StringContent(pw.ToString()), "txtPassword"); // Password

                // Submit the login form
                Log.Debug("Submitting login form {LoginUrl}", loginFormUrl);
                response = await httpClient.PostAsync(loginFormUrl, formData).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                // Check the login status
                var loggedIn = cookieContainer.GetCookies(new Uri(rootUrl))["loggedInAsSubscriber"]?.Value;
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
            catch (HttpRequestException e)
            {
                Log.Error(e, "Login failed");
            }

            return success;
        }

        public async Task<KeepAliveResult> KeepAlive()
        {
            Log.Information("Sending keepalive");

            var status = KeepAliveResult.Unknown;
            try
            {
                Log.Debug("Posting keepalive to {KeepAliveUrl}", keepAliveUrl);
                // The Alarm.com web interface does this with an empty POST, but it seems to work using GET, and makes more sense that way
                var response = await httpClient.GetAsync($"{keepAliveUrl}?timestamp={DateTimeOffset.Now.ToUnixTimeMilliseconds()}").ConfigureAwait(false);
                var result = KeepAliveResponse.FromJson(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                status = result.Status;
                if (status == KeepAliveResult.Success)
                {
                    Log.Debug("Keepalive successful");
                }
                else
                {
                    Log.Error("Keepalive failed: {Status}", status);
                }
            }
            catch (HttpRequestException e)
            {
                Log.Error(e, "Keepalive failed");
            }

            return status;
        }

        private async Task<string> getJsonData(string requestUrl)
        {
            var json = string.Empty;

            try
            {
                Log.Debug("Requesting {Url}", requestUrl);
                var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                var key = cookieContainer.GetCookies(new Uri(requestUrl))["afg"]?.Value;
                if (key != null)
                {
                    request.Headers.Add("AjaxRequestUniqueKey", key);
                }
                request.Headers.Accept.ParseAdd("application/vnd.api+json");

                var response = await httpClient.SendAsync(request).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Log.Debug("Got {Data}", json);
                }
                else
                {
                    var errorData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Log.Error("Request failed: {ErrorData}", errorData);
                }
            }
            catch (HttpRequestException e)
            {
                Log.Error(e, "Request failed");
            }

            return json;
        }

        public async Task<List<SystemItemData>> GetAvailableSystems()
        {
            Log.Information("Getting available system items");

            var json = await getJsonData(availableSystemItemsUrl).ConfigureAwait(false);

            var availableSystemItems = AvailableSystemItems.FromJson(json);

            return availableSystemItems.Data;
        }

        public async Task<SystemData> GetSystemData(SystemItemData systemItem)
        {
            Log.Information("Getting information for {SystemName} system", systemItem.Attributes.Name);
            Log.Debug("Requesting information for system ID {SystemId}", systemItem.Id);

            var requestUrl = systemsUrl + systemItem.Id;

            var json = await getJsonData(requestUrl).ConfigureAwait(false);

            var system = Systems.FromJson(json);

            return system.Data;
        }

        public async Task<ThermostatData> GetThermostatData(string thermostatId)
        {
            Log.Information("Getting thermostat info");
            Log.Debug("Requesting information for thermostat ID {ThermostatId}", thermostatId);

            var requestUrl = thermostatsUrl + thermostatId;

            var json = await getJsonData(requestUrl).ConfigureAwait(false);

            var thermostat = ThermostatInfo.FromJson(json);

            return thermostat.Data;
        }

        public async Task<TemperatureSensorData> GetTemperatureSensorData(string temperatureSensorId)
        {
            Log.Information("Getting temperature sensor info");
            Log.Debug("Requesting information for temperature sensor ID {TemperatureSensorId}", temperatureSensorId);

            var requestUrl = temperatureSensorsUrl + temperatureSensorId;

            var json = await getJsonData(requestUrl).ConfigureAwait(false);

            var temperatureSensor = TemperatureSensorInfo.FromJson(json);

            return temperatureSensor.Data;
        }
    }
}
