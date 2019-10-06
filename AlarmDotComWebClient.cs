using Serilog;
using System;
using System.Net;

namespace AlarmDotCom
{
    internal class AlarmDotComWebClient : WebClient
    {
        public CookieContainer CookieContainer { get; } = new CookieContainer();
        public string UserAgent { get; set; }

        public AlarmDotComWebClient()
        {
            Log.Debug("AlarmDotComWebClient created");
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            Log.Debug("Building WebRequest for {Url}", address);

            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.CookieContainer = CookieContainer;
            request.UserAgent = UserAgent;

            var key = CookieContainer.GetCookies(address)["afg"]?.Value;
            if (key != null)
            {
                request.Headers.Add("AjaxRequestUniqueKey", key);
            }

            if (address.AbsolutePath.StartsWith("/web/api/"))
            {
                request.Accept = "application/vnd.api+json";
            }

            return request;

        }
    }
}
