using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlarmDotCom.JsonObjects
{
    public class KeepAliveResponse
    {
        [JsonPropertyName("status")]
        public KeepAliveStatus Status { get; set; }

        public static KeepAliveResponse FromJson(string json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new KeepAliveStatusConverter());

            return JsonSerializer.Deserialize<KeepAliveResponse>(json, options);
        }
    }
}
