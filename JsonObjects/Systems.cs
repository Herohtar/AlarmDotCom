using Newtonsoft.Json;
using System.Collections.Generic;

namespace AlarmDotCom.JsonObjects.Systems
{
    public partial class Systems
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("included")]
        public List<object> Included { get; set; }

        [JsonProperty("meta")]
        public SystemsMeta Meta { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public Relationships Relationships { get; set; }
    }

    public partial class Attributes
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("hasSnapShotCameras")]
        public bool HasSnapShotCameras { get; set; }

        [JsonProperty("supportsSecureArming")]
        public bool SupportsSecureArming { get; set; }

        [JsonProperty("remainingImageQuota")]
        public long RemainingImageQuota { get; set; }

        [JsonProperty("systemGroupName")]
        public string SystemGroupName { get; set; }

        [JsonProperty("unitId")]
        public long UnitId { get; set; }
    }

    public partial class Relationships
    {
        [JsonProperty("partitions")]
        public PuneHedgehog Partitions { get; set; }

        [JsonProperty("locks")]
        public PuneHedgehog Locks { get; set; }

        [JsonProperty("accessControlAccessPointDevices")]
        public PuneHedgehog AccessControlAccessPointDevices { get; set; }

        [JsonProperty("cameras")]
        public PuneHedgehog Cameras { get; set; }

        [JsonProperty("sdCardCameras")]
        public PuneHedgehog SdCardCameras { get; set; }

        [JsonProperty("garageDoors")]
        public PuneHedgehog GarageDoors { get; set; }

        [JsonProperty("waterValves")]
        public PuneHedgehog WaterValves { get; set; }

        [JsonProperty("scenes")]
        public PuneHedgehog Scenes { get; set; }

        [JsonProperty("sensors")]
        public PuneHedgehog Sensors { get; set; }

        [JsonProperty("waterSensors")]
        public PuneHedgehog WaterSensors { get; set; }

        [JsonProperty("sumpPumps")]
        public PuneHedgehog SumpPumps { get; set; }

        [JsonProperty("waterMeters")]
        public PuneHedgehog WaterMeters { get; set; }

        [JsonProperty("lights")]
        public PuneHedgehog Lights { get; set; }

        [JsonProperty("x10Lights")]
        public PuneHedgehog X10Lights { get; set; }

        [JsonProperty("thermostats")]
        public PuneHedgehog Thermostats { get; set; }

        [JsonProperty("remoteTemperatureSensors")]
        public PuneHedgehog RemoteTemperatureSensors { get; set; }

        [JsonProperty("valveSwitches")]
        public PuneHedgehog ValveSwitches { get; set; }

        [JsonProperty("boilerControlSystem")]
        public BoilerControlSystem BoilerControlSystem { get; set; }

        [JsonProperty("geoDevices")]
        public PuneHedgehog GeoDevices { get; set; }

        [JsonProperty("fences")]
        public PuneHedgehog Fences { get; set; }

        [JsonProperty("imageSensors")]
        public PuneHedgehog ImageSensors { get; set; }

        [JsonProperty("configuration")]
        public BoilerControlSystem Configuration { get; set; }

        [JsonProperty("shades")]
        public PuneHedgehog Shades { get; set; }

        [JsonProperty("lutronShades")]
        public PuneHedgehog LutronShades { get; set; }
    }

    public partial class PuneHedgehog
    {
        [JsonProperty("data")]
        public List<Dat> Data { get; set; }

        [JsonProperty("meta")]
        public PurpleMeta Meta { get; set; }
    }

    public partial class Dat
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class PurpleMeta
    {
        [JsonProperty("count")]
        public string Count { get; set; }
    }

    public partial class BoilerControlSystem
    {
        [JsonProperty("data")]
        public Dat Data { get; set; }
    }

    public partial class SystemsMeta
    {
        [JsonProperty("transformer_version")]
        public string TransformerVersion { get; set; }
    }

    public partial class Systems
    {
        public static Systems FromJson(string json) => JsonConvert.DeserializeObject<Systems>(json, Converter.Settings);
    }
}
