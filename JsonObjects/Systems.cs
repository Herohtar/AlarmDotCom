using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlarmDotCom.JsonObjects.Systems
{
    internal class Systems
    {
        [JsonPropertyName("data")]
        public SystemData Data { get; set; }

        [JsonPropertyName("included")]
        public List<object> Included { get; set; }

        [JsonPropertyName("meta")]
        public ItemMeta Meta { get; set; }

        public static Systems FromJson(string json) => JsonSerializer.Deserialize<Systems>(json);
    }

    public class SystemData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }

        [JsonPropertyName("relationships")]
        public Relationships Relationships { get; set; }
    }

    public class Attributes
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("hasSnapShotCameras")]
        public bool HasSnapShotCameras { get; set; }

        [JsonPropertyName("supportsSecureArming")]
        public bool SupportsSecureArming { get; set; }

        [JsonPropertyName("remainingImageQuota")]
        public int RemainingImageQuota { get; set; }

        [JsonPropertyName("systemGroupName")]
        public string SystemGroupName { get; set; }

        [JsonPropertyName("unitId")]
        public int UnitId { get; set; }
    }

    public class Relationships
    {
        [JsonPropertyName("partitions")]
        public SystemInfo Partitions { get; set; }

        [JsonPropertyName("locks")]
        public SystemInfo Locks { get; set; }

        [JsonPropertyName("accessControlAccessPointDevices")]
        public SystemInfo AccessControlAccessPointDevices { get; set; }

        [JsonPropertyName("cameras")]
        public SystemInfo Cameras { get; set; }

        [JsonPropertyName("sdCardCameras")]
        public SystemInfo SdCardCameras { get; set; }

        [JsonPropertyName("garageDoors")]
        public SystemInfo GarageDoors { get; set; }

        [JsonPropertyName("waterValves")]
        public SystemInfo WaterValves { get; set; }

        [JsonPropertyName("scenes")]
        public SystemInfo Scenes { get; set; }

        [JsonPropertyName("sensors")]
        public SystemInfo Sensors { get; set; }

        [JsonPropertyName("waterSensors")]
        public SystemInfo WaterSensors { get; set; }

        [JsonPropertyName("sumpPumps")]
        public SystemInfo SumpPumps { get; set; }

        [JsonPropertyName("waterMeters")]
        public SystemInfo WaterMeters { get; set; }

        [JsonPropertyName("lights")]
        public SystemInfo Lights { get; set; }

        [JsonPropertyName("x10Lights")]
        public SystemInfo X10Lights { get; set; }

        [JsonPropertyName("thermostats")]
        public SystemInfo Thermostats { get; set; }

        [JsonPropertyName("remoteTemperatureSensors")]
        public SystemInfo RemoteTemperatureSensors { get; set; }

        [JsonPropertyName("valveSwitches")]
        public SystemInfo ValveSwitches { get; set; }

        [JsonPropertyName("boilerControlSystem")]
        public SystemInfo BoilerControlSystem { get; set; }

        [JsonPropertyName("geoDevices")]
        public SystemInfo GeoDevices { get; set; }

        [JsonPropertyName("fences")]
        public SystemInfo Fences { get; set; }

        [JsonPropertyName("imageSensors")]
        public SystemInfo ImageSensors { get; set; }

        [JsonPropertyName("configuration")]
        public Datum Configuration { get; set; }

        [JsonPropertyName("shades")]
        public SystemInfo Shades { get; set; }

        [JsonPropertyName("lutronShades")]
        public SystemInfo LutronShades { get; set; }
    }

    public class SystemInfo
    {
        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }
}
