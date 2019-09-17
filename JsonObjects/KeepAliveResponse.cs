using Newtonsoft.Json;

namespace AlarmDotCom.JsonObjects
{
    public partial class KeepAliveResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class KeepAliveResponse
    {
        public static KeepAliveResponse FromJson(string json) => JsonConvert.DeserializeObject<KeepAliveResponse>(json, Converter.Settings);
    }
}
