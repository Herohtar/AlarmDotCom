using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace AlarmDotCom.JsonObjects
{
    public static class Serialize
    {
        public static string ToJson(this ResponseData.ResponseData self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this AvailableSystemItems.AvailableSystemItems self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this Systems.Systems self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this ThermostatInfo.ThermostatInfo self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this TemperatureSensorInfo.TemperatureSensorInfo self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this KeepAliveResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter()
                {
                    DateTimeStyles = DateTimeStyles.AssumeUniversal,
                },
            },
        };
    }
}
