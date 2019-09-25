using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlarmDotCom.JsonObjects.TemperatureSensorInfo
{
    public class TemperatureSensorInfo
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }

        [JsonPropertyName("included")]
        public List<object> Included { get; set; }

        [JsonPropertyName("meta")]
        public TemperatureSensorInfoMeta Meta { get; set; }

        public static TemperatureSensorInfo FromJson(string json) => JsonSerializer.Deserialize<TemperatureSensorInfo>(json);
    }

    public class Data
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
        [JsonPropertyName("state")]
        public int State { get; set; }

        [JsonPropertyName("ambientTemp")]
        public float AmbientTemp { get; set; }

        [JsonPropertyName("isPaired")]
        public bool IsPaired { get; set; }

        [JsonPropertyName("tempForwardingActive")]
        public bool TempForwardingActive { get; set; }

        [JsonPropertyName("canBeSaved")]
        public bool CanBeSaved { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("canConfirmStateChange")]
        public bool CanConfirmStateChange { get; set; }

        [JsonPropertyName("hasPermissionToChangeState")]
        public bool HasPermissionToChangeState { get; set; }

        [JsonPropertyName("deviceIcon")]
        public DeviceIcon DeviceIcon { get; set; }

        [JsonPropertyName("batteryLevelNull")]
        public object BatteryLevelNull { get; set; }

        [JsonPropertyName("lowBattery")]
        public bool LowBattery { get; set; }

        [JsonPropertyName("criticalBattery")]
        public bool CriticalBattery { get; set; }
    }

    public class DeviceIcon
    {
        [JsonPropertyName("icon")]
        public int Icon { get; set; }
    }

    public class Relationships
    {
        [JsonPropertyName("thermostat")]
        public Thermostat Thermostat { get; set; }

        [JsonPropertyName("system")]
        public System System { get; set; }

        [JsonPropertyName("stateInfo")]
        public StateInfo StateInfo { get; set; }
    }

    public class Thermostat
    {
        [JsonPropertyName("data")]
        public Datum Data { get; set; }
    }

    public class Datum
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class System
    {
        [JsonPropertyName("data")]
        public Datum Data { get; set; }
    }

    public class StateInfo
    {
        [JsonPropertyName("data")]
        public Datum Data { get; set; }
    }

    public class TemperatureSensorInfoMeta
    {
        [JsonPropertyName("transformer_version")]
        public string TransformerVersion { get; set; }
    }
}
