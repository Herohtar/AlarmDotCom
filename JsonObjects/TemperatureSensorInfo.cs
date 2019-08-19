using Newtonsoft.Json;
using System.Collections.Generic;

namespace AlarmDotCom.JsonObjects.TemperatureSensorInfo
{
    public partial class TemperatureSensorInfo
    {
        [JsonProperty("value")]
        public Value Value { get; set; }

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
        [JsonProperty("state")]
        public long State { get; set; }

        [JsonProperty("thermostat")]
        public StateInfo Thermostat { get; set; }

        [JsonProperty("ambientTemp")]
        public long AmbientTemp { get; set; }

        [JsonProperty("isPaired")]
        public bool IsPaired { get; set; }

        [JsonProperty("system")]
        public ValueSystem System { get; set; }

        [JsonProperty("canBeSaved")]
        public bool CanBeSaved { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("stateInfo")]
        public StateInfo StateInfo { get; set; }

        [JsonProperty("canConfirmStateChange")]
        public bool CanConfirmStateChange { get; set; }

        [JsonProperty("hasPermissionToChangeState")]
        public bool HasPermissionToChangeState { get; set; }

        [JsonProperty("deviceIcon")]
        public DeviceIcon DeviceIcon { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class DeviceIcon
    {
        [JsonProperty("icon")]
        public long Icon { get; set; }
    }

    public partial class StateInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class ValueSystem
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public partial class TemperatureSensorInfo
    {
        public static TemperatureSensorInfo FromJson(string json) => JsonConvert.DeserializeObject<TemperatureSensorInfo>(json, Converter.Settings);
    }
}
