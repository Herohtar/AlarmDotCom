using Newtonsoft.Json;
using System.Collections.Generic;

namespace AlarmDotCom.JsonObjects.AvailableSystemItems
{
    public partial class AvailableSystemItems
    {
        [JsonProperty("value")]
        public List<Value> Value { get; set; }

        [JsonProperty("metaData")]
        public MetaData MetaData { get; set; }

        [JsonProperty("errors")]
        public List<object> Errors { get; set; }
    }

    public partial class MetaData
    {
    }

    public partial class Value
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("isSelected")]
        public bool IsSelected { get; set; }

        [JsonProperty("subItems")]
        public List<object> SubItems { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class AvailableSystemItems
    {
        public static AvailableSystemItems FromJson(string json) => JsonConvert.DeserializeObject<AvailableSystemItems>(json, Converter.Settings);
    }
}
