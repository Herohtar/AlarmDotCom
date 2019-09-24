using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlarmDotCom.JsonObjects.AvailableSystemItems
{
    public class AvailableSystemItems
    {
        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; }

        [JsonPropertyName("included")]
        public List<object> Included { get; set; }

        [JsonPropertyName("meta")]
        public AvailableSystemItemsMeta Meta { get; set; }

        public static AvailableSystemItems FromJson(string json) => JsonSerializer.Deserialize<AvailableSystemItems>(json);
    }

    public class AvailableSystemItemsMeta
    {
        [JsonPropertyName("transformer_version")]
        public string TransformerVersion { get; set; }
    }

    public class Datum
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }

        [JsonPropertyName("relationships")]
        public Relationships Relationships { get; set; }
    }

    public class Attributes
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("isSelected")]
        public bool IsSelected { get; set; }
    }

    public class Relationships
    {
        [JsonPropertyName("subItems")]
        public SubItems SubItems { get; set; }
    }

    public class SubItems
    {
        [JsonPropertyName("data")]
        public List<object> Data { get; set; }

        [JsonPropertyName("meta")]
        public SubItemsMeta Meta { get; set; }
    }

    public class SubItemsMeta
    {
        [JsonPropertyName("count")]
        public string Count { get; set; }
    }
}
