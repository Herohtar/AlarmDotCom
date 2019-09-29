using System.Text.Json.Serialization;

namespace AlarmDotCom.JsonObjects
{
    public class Meta
    {
        [JsonPropertyName("count")]
        public string Count { get; set; }
    }
}
