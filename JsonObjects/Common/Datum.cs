using System.Text.Json.Serialization;

namespace AlarmDotCom.JsonObjects
{
    public class Datum
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
