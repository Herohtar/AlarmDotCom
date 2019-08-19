using Newtonsoft.Json;
using System.Collections.Generic;

namespace AlarmDotCom.JsonObjects.Systems
{
    public partial class Systems
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
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("partitions")]
        public List<Light> Partitions { get; set; }

        [JsonProperty("locks")]
        public List<Light> Locks { get; set; }

        [JsonProperty("accessControlAccessPointDevices")]
        public List<object> AccessControlAccessPointDevices { get; set; }

        [JsonProperty("holidays")]
        public List<object> Holidays { get; set; }

        [JsonProperty("cameras")]
        public List<object> Cameras { get; set; }

        [JsonProperty("garageDoors")]
        public List<object> GarageDoors { get; set; }

        [JsonProperty("waterValves")]
        public List<object> WaterValves { get; set; }

        [JsonProperty("scenes")]
        public List<Scene> Scenes { get; set; }

        [JsonProperty("sensors")]
        public List<Sensor> Sensors { get; set; }

        [JsonProperty("waterSensors")]
        public List<object> WaterSensors { get; set; }

        [JsonProperty("sumpPumps")]
        public List<object> SumpPumps { get; set; }

        [JsonProperty("waterMeters")]
        public List<object> WaterMeters { get; set; }

        [JsonProperty("lights")]
        public List<Light> Lights { get; set; }

        [JsonProperty("x10Lights")]
        public List<object> X10Lights { get; set; }

        [JsonProperty("thermostats")]
        public List<Thermostat> Thermostats { get; set; }

        [JsonProperty("remoteTemperatureSensors")]
        public List<RemoteTemperatureSensor> RemoteTemperatureSensors { get; set; }

        [JsonProperty("valveSwitches")]
        public List<object> ValveSwitches { get; set; }

        [JsonProperty("imageSensors")]
        public List<ImageSensor> ImageSensors { get; set; }

        [JsonProperty("remainingImageQuota")]
        public long RemainingImageQuota { get; set; }

        [JsonProperty("systemGroupName")]
        public string SystemGroupName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public partial class ImageSensor
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public partial class Light
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class Thermostat
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class RemoteTemperatureSensor
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class Scene
    {
        [JsonProperty("system")]
        public ImageSensor System { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public partial class Sensor
    {
        [JsonProperty("isNormalActivityMonitoringEligible")]
        public bool IsNormalActivityMonitoringEligible { get; set; }

        [JsonProperty("system")]
        public ImageSensor System { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class Systems
    {
        public static Systems FromJson(string json) => JsonConvert.DeserializeObject<Systems>(json, Converter.Settings);
    }
}
