using Newtonsoft.Json;
using System.Collections.Generic;

namespace AlarmDotCom.JsonObjects.ThermostatInfo
{
    public partial class ThermostatInfo
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
        [JsonProperty("forwardingAmbientTemp")]
        public long ForwardingAmbientTemp { get; set; }

        [JsonProperty("minHeatSetpoint")]
        public long MinHeatSetpoint { get; set; }

        [JsonProperty("maxHeatSetpoint")]
        public long MaxHeatSetpoint { get; set; }

        [JsonProperty("minCoolSetpoint")]
        public long MinCoolSetpoint { get; set; }

        [JsonProperty("maxCoolSetpoint")]
        public long MaxCoolSetpoint { get; set; }

        [JsonProperty("heatSetpoint")]
        public long HeatSetpoint { get; set; }

        [JsonProperty("desiredHeatSetpoint")]
        public long DesiredHeatSetpoint { get; set; }

        [JsonProperty("coolSetpoint")]
        public long CoolSetpoint { get; set; }

        [JsonProperty("desiredCoolSetpoint")]
        public long DesiredCoolSetpoint { get; set; }

        [JsonProperty("homeHeatSetpoint")]
        public long HomeHeatSetpoint { get; set; }

        [JsonProperty("homeCoolSetpoint")]
        public long HomeCoolSetpoint { get; set; }

        [JsonProperty("awayHeatSetpoint")]
        public long AwayHeatSetpoint { get; set; }

        [JsonProperty("awayCoolSetpoint")]
        public long AwayCoolSetpoint { get; set; }

        [JsonProperty("sleepHeatSetpoint")]
        public long SleepHeatSetpoint { get; set; }

        [JsonProperty("sleepCoolSetpoint")]
        public long SleepCoolSetpoint { get; set; }

        [JsonProperty("setpointOffset")]
        public long SetpointOffset { get; set; }

        [JsonProperty("autoSetpointBuffer")]
        public long AutoSetpointBuffer { get; set; }

        [JsonProperty("state")]
        public long State { get; set; }

        [JsonProperty("desiredState")]
        public long DesiredState { get; set; }

        [JsonProperty("inferredState")]
        public long InferredState { get; set; }

        [JsonProperty("scheduleMode")]
        public long ScheduleMode { get; set; }

        [JsonProperty("fanMode")]
        public long FanMode { get; set; }

        [JsonProperty("desiredFanMode")]
        public long DesiredFanMode { get; set; }

        [JsonProperty("localDisplayLockingMode")]
        public long LocalDisplayLockingMode { get; set; }

        [JsonProperty("ruleSuggestions")]
        public List<RemoteTemperatureSensor> RuleSuggestions { get; set; }

        [JsonProperty("remoteTemperatureSensors")]
        public List<RemoteTemperatureSensor> RemoteTemperatureSensors { get; set; }

        [JsonProperty("isPoolController")]
        public bool IsPoolController { get; set; }

        [JsonProperty("supportsOffMode")]
        public bool SupportsOffMode { get; set; }

        [JsonProperty("supportsHeatMode")]
        public bool SupportsHeatMode { get; set; }

        [JsonProperty("supportsCoolMode")]
        public bool SupportsCoolMode { get; set; }

        [JsonProperty("supportsAutoMode")]
        public bool SupportsAutoMode { get; set; }

        [JsonProperty("supportsSmartSchedules")]
        public bool SupportsSmartSchedules { get; set; }

        [JsonProperty("supportsAuxHeatMode")]
        public bool SupportsAuxHeatMode { get; set; }

        [JsonProperty("supportsSchedules")]
        public bool SupportsSchedules { get; set; }

        [JsonProperty("supportsFanMode")]
        public bool SupportsFanMode { get; set; }

        [JsonProperty("supportsIndefiniteFanOn")]
        public bool SupportsIndefiniteFanOn { get; set; }

        [JsonProperty("supportsCirculateFanModeAlways")]
        public bool SupportsCirculateFanModeAlways { get; set; }

        [JsonProperty("supportsCirculateFanModeWhenOff")]
        public bool SupportsCirculateFanModeWhenOff { get; set; }

        [JsonProperty("supportsRts")]
        public bool SupportsRts { get; set; }

        [JsonProperty("supportsHumidity")]
        public bool SupportsHumidity { get; set; }

        [JsonProperty("supportsLocalDisplayLocking")]
        public bool SupportsLocalDisplayLocking { get; set; }

        [JsonProperty("supportsPartialLocalDisplayLocking")]
        public bool SupportsPartialLocalDisplayLocking { get; set; }

        [JsonProperty("supportsHvacAnalytics")]
        public bool SupportsHvacAnalytics { get; set; }

        [JsonProperty("ambientTemp")]
        public long AmbientTemp { get; set; }

        [JsonProperty("isPaired")]
        public bool IsPaired { get; set; }

        [JsonProperty("tempForwardingActive")]
        public bool TempForwardingActive { get; set; }

        [JsonProperty("system")]
        public ValueSystem System { get; set; }

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
        public long BatteryLevelNull { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class DeviceIcon
    {
        [JsonProperty("icon")]
        public long Icon { get; set; }
    }

    public partial class RemoteTemperatureSensor
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class ValueSystem
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public partial class ThermostatInfo
    {
        public static ThermostatInfo FromJson(string json) => JsonConvert.DeserializeObject<ThermostatInfo>(json, Converter.Settings);
    }
}
