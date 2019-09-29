using System.Text.Json.Serialization;

namespace AlarmDotCom.JsonObjects
{
    public class ItemMeta
    {
        [JsonPropertyName("transformer_version")]
        public string TransformerVersion { get; set; }
    }
}
