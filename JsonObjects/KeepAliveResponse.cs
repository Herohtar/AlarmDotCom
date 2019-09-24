using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlarmDotCom.JsonObjects
{
    public class KeepAliveResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        public static KeepAliveResponse FromJson(string json) => JsonSerializer.Deserialize<KeepAliveResponse>(json);
    }
}
