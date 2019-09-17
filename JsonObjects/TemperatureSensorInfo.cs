using Newtonsoft.Json;
using System.Collections.Generic;

namespace AlarmDotCom.JsonObjects.TemperatureSensorInfo
{
    public partial class TemperatureSensorInfo
    {
        [JsonProperty("data")]
        public TemperatureSensorInfoData Data { get; set; }

        [JsonProperty("included")]
        public List<object> Included { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public partial class TemperatureSensorInfoData
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
        [JsonProperty("state")]
        public long State { get; set; }

        [JsonProperty("ambientTemp")]
        public long AmbientTemp { get; set; }

        [JsonProperty("isPaired")]
        public bool IsPaired { get; set; }

        [JsonProperty("tempForwardingActive")]
        public bool TempForwardingActive { get; set; }

        [JsonProperty("canBeSaved")]
        public bool CanBeSaved { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("canConfirmStateChange")]
        public bool CanConfirmStateChange { get; set; }

        [JsonProperty("hasPermissionToChangeState")]
        public bool HasPermissionToChangeState { get; set; }

        [JsonProperty("deviceIcon")]
        public DeviceIcon DeviceIcon { get; set; }

        [JsonProperty("batteryLevelNull")]
        public object BatteryLevelNull { get; set; }

        [JsonProperty("lowBattery")]
        public bool LowBattery { get; set; }

        [JsonProperty("criticalBattery")]
        public bool CriticalBattery { get; set; }
    }

    public partial class DeviceIcon
    {
        [JsonProperty("icon")]
        public long Icon { get; set; }
    }

    public partial class Relationships
    {
        [JsonProperty("thermostat")]
        public StateInfo Thermostat { get; set; }

        [JsonProperty("system")]
        public StateInfo System { get; set; }

        [JsonProperty("stateInfo")]
        public StateInfo StateInfo { get; set; }
    }

    public partial class StateInfo
    {
        [JsonProperty("data")]
        public StateInfoData Data { get; set; }
    }

    public partial class StateInfoData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("transformer_version")]
        public string TransformerVersion { get; set; }
    }

    public partial class TemperatureSensorInfo
    {
        public static TemperatureSensorInfo FromJson(string json) => JsonConvert.DeserializeObject<TemperatureSensorInfo>(json, Converter.Settings);
    }
}
