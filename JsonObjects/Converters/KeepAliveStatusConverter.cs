using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlarmDotCom
{
    internal class KeepAliveStatusConverter : JsonConverter<KeepAliveStatus>
    {
        public override KeepAliveStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value.Equals("Keep Alive", StringComparison.OrdinalIgnoreCase))
            {
                return KeepAliveStatus.Success;
            }
            else if (value.Equals("Session Expired", StringComparison.OrdinalIgnoreCase))
            {
                return KeepAliveStatus.SessionExpired;
            }

            return KeepAliveStatus.Error;
        }

        public override void Write(Utf8JsonWriter writer, KeepAliveStatus value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
