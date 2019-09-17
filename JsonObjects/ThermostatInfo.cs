using Newtonsoft.Json;
using System.Collections.Generic;

namespace AlarmDotCom.JsonObjects.ThermostatInfo
{
    public partial class ThermostatInfo
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("included")]
        public List<object> Included { get; set; }

        [JsonProperty("meta")]
        public ThermostatInfoMeta Meta { get; set; }
    }

    public partial class Data
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
        [JsonProperty("requiresSetup")]
        public bool RequiresSetup { get; set; }

        [JsonProperty("forwardingAmbientTemp")]
        public long ForwardingAmbientTemp { get; set; }

        [JsonProperty("humidityLevel")]
        public object HumidityLevel { get; set; }

        [JsonProperty("minHeatSetpoint")]
        public long MinHeatSetpoint { get; set; }

        [JsonProperty("maxHeatSetpoint")]
        public long MaxHeatSetpoint { get; set; }

        [JsonProperty("minCoolSetpoint")]
        public long MinCoolSetpoint { get; set; }

        [JsonProperty("maxCoolSetpoint")]
        public long MaxCoolSetpoint { get; set; }

        [JsonProperty("minAuxHeatSetpoint")]
        public long MinAuxHeatSetpoint { get; set; }

        [JsonProperty("maxAuxHeatSetpoint")]
        public long MaxAuxHeatSetpoint { get; set; }

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

        [JsonProperty("thirdPartySettingsUrlDesc")]
        public object ThirdPartySettingsUrlDesc { get; set; }

        [JsonProperty("thirdPartySettingsUrl")]
        public object ThirdPartySettingsUrl { get; set; }

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

        [JsonProperty("fanDuration")]
        public object FanDuration { get; set; }

        [JsonProperty("localDisplayLockingMode")]
        public long LocalDisplayLockingMode { get; set; }

        [JsonProperty("desiredLocalDisplayLockingMode")]
        public object DesiredLocalDisplayLockingMode { get; set; }

        [JsonProperty("hasRtsIssue")]
        public bool HasRtsIssue { get; set; }

        [JsonProperty("supportsSetpoints")]
        public bool SupportsSetpoints { get; set; }

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

        [JsonProperty("supportedFanDurations")]
        public List<long> SupportedFanDurations { get; set; }

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

        [JsonProperty("supportsThirdPartySettings")]
        public bool SupportsThirdPartySettings { get; set; }

        [JsonProperty("hasPendingTempModeChange")]
        public bool HasPendingTempModeChange { get; set; }

        [JsonProperty("hasPendingSetpointChange")]
        public bool HasPendingSetpointChange { get; set; }

        [JsonProperty("hasPendingHeatSetpointChange")]
        public bool HasPendingHeatSetpointChange { get; set; }

        [JsonProperty("hasPendingCoolSetpointChange")]
        public bool HasPendingCoolSetpointChange { get; set; }

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
        public long BatteryLevelNull { get; set; }

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
        [JsonProperty("ruleSuggestions")]
        public RemoteTemperatureSensors RuleSuggestions { get; set; }

        [JsonProperty("thermostatSettingsTemplate")]
        public BoilerControlSystem ThermostatSettingsTemplate { get; set; }

        [JsonProperty("remoteTemperatureSensors")]
        public RemoteTemperatureSensors RemoteTemperatureSensors { get; set; }

        [JsonProperty("boilerControlSystem")]
        public BoilerControlSystem BoilerControlSystem { get; set; }

        [JsonProperty("system")]
        public BoilerControlSystem System { get; set; }

        [JsonProperty("stateInfo")]
        public BoilerControlSystem StateInfo { get; set; }
    }

    public partial class BoilerControlSystem
    {
        [JsonProperty("data")]
        public Dat Data { get; set; }
    }

    public partial class Dat
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class RemoteTemperatureSensors
    {
        [JsonProperty("data")]
        public List<Dat> Data { get; set; }

        [JsonProperty("meta")]
        public RemoteTemperatureSensorsMeta Meta { get; set; }
    }

    public partial class RemoteTemperatureSensorsMeta
    {
        [JsonProperty("count")]
        public string Count { get; set; }
    }

    public partial class ThermostatInfoMeta
    {
        [JsonProperty("transformer_version")]
        public string TransformerVersion { get; set; }
    }

    public partial class ThermostatInfo
    {
        public static ThermostatInfo FromJson(string json) => JsonConvert.DeserializeObject<ThermostatInfo>(json, Converter.Settings);
    }
}
