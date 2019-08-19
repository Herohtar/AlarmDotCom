using Newtonsoft.Json;
using System.Collections.Generic;

/*
 * Representation of the JSON object returned from Alarm.com
 * Auto-generated with http://json2csharp.com/
 */
namespace AlarmDotCom.JsonObjects.ResponseData
{
    public partial class ResponseData
    {
        [JsonProperty("d")]
        public D D { get; set; }
    }

    public partial class D
    {
        [JsonProperty("__type")]
        public string Type { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("problem")]
        public bool Problem { get; set; }

        [JsonProperty("successMessage")]
        public List<object> SuccessMessage { get; set; }

        [JsonProperty("errorMessage")]
        public List<object> ErrorMessage { get; set; }

        [JsonProperty("problemMessage")]
        public List<object> ProblemMessage { get; set; }

        [JsonProperty("responseMessage")]
        public EsponseMessage ResponseMessage { get; set; }

        [JsonProperty("errorResponseMessage")]
        public EsponseMessage ErrorResponseMessage { get; set; }

        [JsonProperty("responseObject")]
        public ResponseObject ResponseObject { get; set; }

        [JsonProperty("HasError")]
        public bool HasError { get; set; }
    }

    public partial class EsponseMessage
    {
    }

    public partial class ResponseObject
    {
        [JsonProperty("temperatureSensorsData")]
        public List<TemperatureSensorsDatum> TemperatureSensorsData { get; set; }
    }

    public partial class TemperatureSensorsDatum
    {
        [JsonProperty("DeviceType")]
        public long DeviceType { get; set; }

        [JsonProperty("RemoteTemperatureEnableStatus")]
        public long RemoteTemperatureEnableStatus { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("LowBattery")]
        public bool LowBattery { get; set; }

        [JsonProperty("Malfunction")]
        public bool Malfunction { get; set; }

        [JsonProperty("PairedThermostatId")]
        public long? PairedThermostatId { get; set; }

        [JsonProperty("PairedInManual")]
        public bool PairedInManual { get; set; }

        [JsonProperty("PairedInSchedule")]
        public bool PairedInSchedule { get; set; }

        [JsonProperty("UnitId")]
        public long UnitId { get; set; }

        [JsonProperty("DeviceId")]
        public long DeviceId { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("ReadingType")]
        public long ReadingType { get; set; }

        [JsonProperty("LastKnownReading")]
        public long LastKnownReading { get; set; }

        [JsonProperty("TimestampUtc")]
        public string TimestampUtc { get; set; }

        [JsonProperty("TimeStampTextString")]
        public string TimeStampTextString { get; set; }

        [JsonProperty("HasReading")]
        public bool HasReading { get; set; }
    }

    public partial class ResponseData
    {
        public static ResponseData FromJson(string json) => JsonConvert.DeserializeObject<ResponseData>(json, Converter.Settings);
    }
}
