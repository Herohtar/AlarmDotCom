using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlarmDotCom.JsonObjects
{
    public class KeepAliveResponse
    {
        [JsonPropertyName("status")]
        public KeepAliveResult Status { get; set; }

        public static KeepAliveResponse FromJson(string json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new KeepAliveResultConverter());

            return JsonSerializer.Deserialize<KeepAliveResponse>(json, options);
        }
    }
}
