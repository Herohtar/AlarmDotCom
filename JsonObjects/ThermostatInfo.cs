using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlarmDotCom.JsonObjects.ThermostatInfo
{
    public class ThermostatInfo
    {
        [JsonPropertyName("data")]
        public ThermostatData Data { get; set; }

        [JsonPropertyName("included")]
        public List<object> Included { get; set; }

        [JsonPropertyName("meta")]
        public ItemMeta Meta { get; set; }

        public static ThermostatInfo FromJson(string json) => JsonSerializer.Deserialize<ThermostatInfo>(json);
    }

    public class ThermostatData
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
        [JsonPropertyName("requiresSetup")]
        public bool RequiresSetup { get; set; }

        [JsonPropertyName("forwardingAmbientTemp")]
        public float ForwardingAmbientTemp { get; set; }

        [JsonPropertyName("humidityLevel")]
        public object HumidityLevel { get; set; }

        [JsonPropertyName("minHeatSetpoint")]
        public float MinHeatSetpoint { get; set; }

        [JsonPropertyName("maxHeatSetpoint")]
        public float MaxHeatSetpoint { get; set; }

        [JsonPropertyName("minCoolSetpoint")]
        public float MinCoolSetpoint { get; set; }

        [JsonPropertyName("maxCoolSetpoint")]
        public float MaxCoolSetpoint { get; set; }

        [JsonPropertyName("minAuxHeatSetpoint")]
        public float MinAuxHeatSetpoint { get; set; }

        [JsonPropertyName("maxAuxHeatSetpoint")]
        public float MaxAuxHeatSetpoint { get; set; }

        [JsonPropertyName("heatSetpoint")]
        public float HeatSetpoint { get; set; }

        [JsonPropertyName("desiredHeatSetpoint")]
        public float DesiredHeatSetpoint { get; set; }

        [JsonPropertyName("coolSetpoint")]
        public float CoolSetpoint { get; set; }

        [JsonPropertyName("desiredCoolSetpoint")]
        public float DesiredCoolSetpoint { get; set; }

        [JsonPropertyName("homeHeatSetpoint")]
        public float HomeHeatSetpoint { get; set; }

        [JsonPropertyName("homeCoolSetpoint")]
        public float HomeCoolSetpoint { get; set; }

        [JsonPropertyName("AwayHeatSetpoint")]
        public float AwayHeatSetpoint { get; set; }

        [JsonPropertyName("awayCoolSetpoint")]
        public float AwayCoolSetpoint { get; set; }

        [JsonPropertyName("sleepHeatSetpoint")]
        public float SleepHeatSetpoint { get; set; }

        [JsonPropertyName("sleepCoolSetpoint")]
        public float SleepCoolSetpoint { get; set; }

        [JsonPropertyName("setpointOffset")]
        public float SetpointOffset { get; set; }

        [JsonPropertyName("autoSetpointBuffer")]
        public float AutoSetpointBuffer { get; set; }

        [JsonPropertyName("thirdPartySettingsUrlDesc")]
        public object ThirdPartySettingsUrlDesc { get; set; }

        [JsonPropertyName("thirdPartySettingsUrl")]
        public object ThirdPartySettingsUrl { get; set; }

        [JsonPropertyName("state")]
        public int State { get; set; }

        [JsonPropertyName("desiredState")]
        public int DesiredState { get; set; }

        [JsonPropertyName("inferredState")]
        public int InferredState { get; set; }

        [JsonPropertyName("scheduleMode")]
        public int ScheduleMode { get; set; }

        [JsonPropertyName("fanMode")]
        public int FanMode { get; set; }

        [JsonPropertyName("desiredFanMode")]
        public int DesiredFanMode { get; set; }

        [JsonPropertyName("fanDuration")]
        public object FanDuration { get; set; }

        [JsonPropertyName("localDisplayLockingMode")]
        public int LocalDisplayLockingMode { get; set; }

        [JsonPropertyName("desiredLocalDisplayLockingMode")]
        public object DesiredLocalDisplayLockingMode { get; set; }

        [JsonPropertyName("hasRtsIssue")]
        public bool HasRtsIssue { get; set; }

        [JsonPropertyName("supportsSetpoints")]
        public bool SupportsSetpoints { get; set; }

        [JsonPropertyName("isPoolController")]
        public bool IsPoolController { get; set; }

        [JsonPropertyName("supportsOffMode")]
        public bool SupportsOffMode { get; set; }

        [JsonPropertyName("supportsHeatMode")]
        public bool SupportsHeatMode { get; set; }

        [JsonPropertyName("supportsCoolMode")]
        public bool SupportsCoolMode { get; set; }

        [JsonPropertyName("supportsAutoMode")]
        public bool SupportsAutoMode { get; set; }

        [JsonPropertyName("supportsSmartSchedules")]
        public bool SupportsSmartSchedules { get; set; }

        [JsonPropertyName("supportsAuxHeatMode")]
        public bool SupportsAuxHeatMode { get; set; }

        [JsonPropertyName("supportsSchedules")]
        public bool SupportsSchedules { get; set; }

        [JsonPropertyName("supportsFanMode")]
        public bool SupportsFanMode { get; set; }

        [JsonPropertyName("supportsIndefiniteFanOn")]
        public bool SupportsIndefiniteFanOn { get; set; }

        [JsonPropertyName("supportedFanDurations")]
        public List<int> SupportedFanDurations { get; set; }

        [JsonPropertyName("supportsCirculateFanModeAlways")]
        public bool SupportsCirculateFanModeAlways { get; set; }

        [JsonPropertyName("supportsCirculateFanModeWhenOff")]
        public bool SupportsCirculateFanModeWhenOff { get; set; }

        [JsonPropertyName("supportsRts")]
        public bool SupportsRts { get; set; }

        [JsonPropertyName("supportsHumidity")]
        public bool SupportsHumidity { get; set; }

        [JsonPropertyName("supportsLocalDisplayLocking")]
        public bool SupportsLocalDisplayLocking { get; set; }

        [JsonPropertyName("supportsPartialLocalDisplayLocking")]
        public bool SupportsPartialLocalDisplayLocking { get; set; }

        [JsonPropertyName("supportsHvacAnalytics")]
        public bool SupportsHvacAnalytics { get; set; }

        [JsonPropertyName("supportsThirdPartySettings")]
        public bool SupportsThirdPartySettings { get; set; }

        [JsonPropertyName("hasPendingTempModeChange")]
        public bool HasPendingTempModeChange { get; set; }

        [JsonPropertyName("hasPendingSetpointChange")]
        public bool HasPendingSetpointChange { get; set; }

        [JsonPropertyName("hasPendingHeatSetpointChange")]
        public bool HasPendingHeatSetpointChange { get; set; }

        [JsonPropertyName("hasPendingCoolSetpointChange")]
        public bool HasPendingCoolSetpointChange { get; set; }

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
        public int BatteryLevelNull { get; set; }

        [JsonPropertyName("lowBattery")]
        public bool LowBattery { get; set; }

        [JsonPropertyName("criticalBattery")]
        public bool CriticalBattery { get; set; }
    }

    public class DeviceIcon
    {
        [JsonPropertyName("Icon")]
        public int Icon { get; set; }
    }

    public class Relationships
    {
        [JsonPropertyName("ruleSuggestions")]
        public RuleSuggestions RuleSuggestions { get; set; }

        [JsonPropertyName("thermostatSettingsTemplate")]
        public ThermostatSettingsTemplate ThermostatSettingsTemplate { get; set; }

        [JsonPropertyName("remoteTemperatureSensors")]
        public RemoteTemperatureSensors RemoteTemperatureSensors { get; set; }

        [JsonPropertyName("boilerControlSystem")]
        public BoilerControlSystem BoilerControlSystem { get; set; }

        [JsonPropertyName("system")]
        public System System { get; set; }

        [JsonPropertyName("stateInfo")]
        public StateInfo StateInfo { get; set; }
    }

    public class RuleSuggestions
    {
        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }

    public class ThermostatSettingsTemplate
    {
        [JsonPropertyName("data")]
        public object data { get; set; }
    }

    public class RemoteTemperatureSensors
    {
        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }

    public class BoilerControlSystem
    {
        [JsonPropertyName("data")]
        public object Data { get; set; }
    }

    public class System
    {
        [JsonPropertyName("data")]
        public Datum Data { get; set; }
    }

    public class StateInfo
    {
        [JsonPropertyName("data")]
        public object Data { get; set; }
    }
}
