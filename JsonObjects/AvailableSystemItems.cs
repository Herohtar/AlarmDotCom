using Newtonsoft.Json;
using System.Collections.Generic;

namespace AlarmDotCom.JsonObjects.AvailableSystemItems
{
    public partial class AvailableSystemItems
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("included")]
        public List<object> Included { get; set; }

        [JsonProperty("meta")]
        public AvailableSystemItemsMeta Meta { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public Relationships Relationships { get; set; }
    }

    public partial class Attributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("isSelected")]
        public bool IsSelected { get; set; }
    }

    public partial class Relationships
    {
        [JsonProperty("subItems")]
        public SubItems SubItems { get; set; }
    }

    public partial class SubItems
    {
        [JsonProperty("data")]
        public List<object> Data { get; set; }

        [JsonProperty("meta")]
        public SubItemsMeta Meta { get; set; }
    }

    public partial class SubItemsMeta
    {
        [JsonProperty("count")]
        public string Count { get; set; }
    }

    public partial class AvailableSystemItemsMeta
    {
        [JsonProperty("transformer_version")]
        public string TransformerVersion { get; set; }
    }

    public partial class AvailableSystemItems
    {
        public static AvailableSystemItems FromJson(string json) => JsonConvert.DeserializeObject<AvailableSystemItems>(json, Converter.Settings);
    }
}
