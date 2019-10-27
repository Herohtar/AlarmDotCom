using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlarmDotCom
{
    internal class KeepAliveResultConverter : JsonConverter<KeepAliveResult>
    {
        public override KeepAliveResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value.Equals("Keep Alive", StringComparison.OrdinalIgnoreCase))
            {
                return KeepAliveResult.Success;
            }
            else if (value.Equals("Session Expired", StringComparison.OrdinalIgnoreCase))
            {
                return KeepAliveResult.SessionExpired;
            }

            return KeepAliveResult.Error;
        }

        public override void Write(Utf8JsonWriter writer, KeepAliveResult value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
