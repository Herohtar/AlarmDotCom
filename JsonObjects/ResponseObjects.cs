using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlarmDotCom.JsonObjects.ResponseData
{
    public class ResponseData
    {
        [JsonPropertyName("d")]
        public D D { get; set; }

        public static ResponseData FromJson(string json) => JsonSerializer.Deserialize<ResponseData>(json);
    }

    public class D
    {
        [JsonPropertyName("__type")]
        public string Type { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("problem")]
        public bool Problem { get; set; }

        [JsonPropertyName("successMessage")]
        public List<object> SuccessMessage { get; set; }

        [JsonPropertyName("errorMessage")]
        public List<object> ErrorMessage { get; set; }

        [JsonPropertyName("problemMessage")]
        public List<object> ProblemMessage { get; set; }

        [JsonPropertyName("responseMessage")]
        public ResponseMessage ResponseMessage { get; set; }

        [JsonPropertyName("errorResponseMessage")]
        public ErrorResponseMessage ErrorResponseMessage { get; set; }

        [JsonPropertyName("responseObject")]
        public ResponseObject ResponseObject { get; set; }

        public bool HasError { get; set; }
    }

    public class ResponseMessage
    {
    }

    public class ErrorResponseMessage
    {
    }

    public class ResponseObject
    {
        [JsonPropertyName("temperatureSensorsData")]
        public List<TemperatureSensorsData> TemperatureSensorsData { get; set; }
    }

    public class TemperatureSensorsData
    {
        public int DeviceType { get; set; }

        public int RemoteTemperatureEnableStatus { get; set; }

        public bool IsActive { get; set; }

        public bool LowBattery { get; set; }

        public bool Malfunction { get; set; }

        public int? PairedThermostatId { get; set; }

        public bool PairedInManual { get; set; }

        public bool PairedInSchedule { get; set; }

        public int UnitId { get; set; }

        public int DeviceId { get; set; }

        public string Description { get; set; }

        public int ReadingType { get; set; }

        public int LastKnownReading { get; set; }

        public DateTime TimestampUtc { get; set; }

        public string TimeStampTextString { get; set; }

        public bool HasReading { get; set; }
    }
}
