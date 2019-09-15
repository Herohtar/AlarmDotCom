using AlarmDotCom.JsonObjects.ResponseData;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace AlarmDotCom
{
    /// <summary>
    /// Alarm.com doesn't provide a public API. This class allows you to log in and obtain a valid session for making JSON requests
    /// </summary>
    public class Client : WebClient
    {
        private string un;
        private string pw;

        private const string rootUrl = @"https://www.alarm.com";
        private const string initialPageUrl = @"https://www.alarm.com/login.aspx";
        private const string loginFormUrl = @"https://www.alarm.com/web/Default.aspx";
        private const string keepAliveUrl = @"https://www.alarm.com/web/KeepAlive.aspx";
        private const string temperatureSensorDataUrl = @"https://www.alarm.com/web/Dashboard/WebServices/Dashboard.asmx/TemperatureSensorDataRefresh";
        private const string availableSystemItemsUrl = @"https://www.alarm.com/web/api/systems/availableSystemItems";
        private const string systemsUrl = @"https://www.alarm.com/web/api/systems/systems/";
        private const string thermostatsUrl = @"https://www.alarm.com/web/api/devices/thermostats/";
        private const string temperatureSensorsUrl = @"https://www.alarm.com/web/api/devices/remoteTemperatureSensors/";

        private const string userAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:55.0) Gecko/20100101 Firefox/55.0"; // An actual user agent string so our request looks like it's from a real browser

        public Client(string username, string password, CookieContainer container, string ajax)
        {
            CookieContainer = container;
            AjaxRequestHeader = ajax;
            un = username;
            pw = password;
        }

        public Client(string username, string password)
          : this(username, password, new CookieContainer(), string.Empty)
        { }

        public bool Login()
        {
            var success = false;
            try
            {
                var loginData = new NameValueCollection();
                var pageHtml = new HtmlDocument();
                HttpWebRequest request;
                WebResponse response;

                // Load the first page in order to pull the ASP states/keys so our login request looks legit
                request = (HttpWebRequest)WebRequest.Create(initialPageUrl);
                request.Method = "GET";
                request.UserAgent = userAgent;
                response = request.GetResponse();

                // Parse the response and create the login headers
                pageHtml.Load(response.GetResponseStream());
                // We need all the hidden ASP.NET state/event values. Grab everything that starts with double underscores just to make sure we get everything
                pageHtml.DocumentNode.Descendants("input").Where(i => i.Id.StartsWith("__")).ToList().ForEach(i => loginData.Add(i.Id, i.GetAttributeValue("value", string.Empty)));
                loginData.Add("IsFromNewSite", "1"); // Not sure what this does exactly, but it seems necessary to include it
                loginData.Add("JavaScriptTest", "1"); // Lie and say we support JavaScript
                loginData.Add("ctl00$ContentPlaceHolder1$loginform$txtUserName", un); // Username
                loginData.Add("txtPassword", pw.ToString()); // Password

                // Set up the actual login
                request = (HttpWebRequest)WebRequest.Create(loginFormUrl);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = userAgent;
                request.Referer = initialPageUrl;

                // Write the header
                var data = string.Join("&", loginData.Cast<string>().Select(key => $"{key}={loginData[key]}"));
                var buffer = Encoding.ASCII.GetBytes(data);
                request.ContentLength = buffer.Length;
                var requestStream = request.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Close();

                request.CookieContainer = new CookieContainer();

                // Submit the login and parse the response
                response = request.GetResponse();
                response.Close();

                // Steal the request key and cookies for ourselves
                CookieContainer = request.CookieContainer;
                var cookies = CookieContainer.GetCookies(new Uri(rootUrl)).OfType<Cookie>();

                if (cookies.Any(cookie => cookie.Name.Equals("loggedInAsSubscriber") && cookie.Value.Equals("1")))
                {
                    var key = (from cookie in cookies
                               where cookie.Name.Equals("afg")
                               select cookie.Value).FirstOrDefault();

                    if (key != null)
                    {
                        AjaxRequestHeader = key;
                        success = true;
                    }
                }
            }
            catch (Exception e)
            {
                // Do nothing
            }

            return success;
        }

        public bool KeepAlive()
        {
            var success = false;
            try
            {
                var response = UploadString(keepAliveUrl, $"timestamp={DateTimeOffset.Now.ToUnixTimeMilliseconds()}");
                success = true;
            }
            catch (WebException e)
            {
                System.Diagnostics.Debug.WriteLine($"{DateTime.Now}: Error - {e.Message}");
            }

            return success;
        }

        public List<TemperatureSensorsDatum> GetSensorData(int temperatureSensorPollFrequency)
        {
            string response = null;
            var success = false;
            do
            {
                try
                {
                    response = UploadString(temperatureSensorDataUrl, $"{{\"temperaturesensorPollFrequency\":{temperatureSensorPollFrequency}}}");
                    success = true;
                }
                catch (WebException e)
                {
                    System.Diagnostics.Debug.WriteLine($"{DateTime.Now}: Logging back in... {e.Message}");
                    Login();
                }
            } while (!success);

            var responseData = ResponseData.FromJson(response);

            return responseData.D.ResponseObject.TemperatureSensorsData;
        }

        public CookieContainer CookieContainer { get; private set; }

        public string AjaxRequestHeader { get; private set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.CookieContainer = CookieContainer;
            request.Headers.Add("AjaxRequestUniqueKey", AjaxRequestHeader);
            request.UserAgent = userAgent;
            request.ContentType = "application/json; charset=utf-8";
            return request;
        }
    }
}
