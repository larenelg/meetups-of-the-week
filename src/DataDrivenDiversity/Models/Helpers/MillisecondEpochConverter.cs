using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DataDrivenDiversity.Models.Helpers
{
    

    public class MillisecondEpochConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return DateTimeCoverter.EpochToDateTime((long)reader.Value, 0);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}