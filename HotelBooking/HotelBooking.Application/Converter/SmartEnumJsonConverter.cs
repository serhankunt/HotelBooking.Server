using Ardalis.SmartEnum;
using Newtonsoft.Json;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace HotelBooking.Application.Converter;

public class SmartEnumJsonConverter<T> : JsonConverter where T : SmartEnum<T>
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is T smartEnum)
        {
            writer.WriteValue(smartEnum.Name);
        }
        else
        {
            writer.WriteNull();
        }
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.Value is string name)
        {
            return SmartEnum<T>.FromName(name);
        }
        return null;
    }

    public override bool CanConvert(Type objectType)
    {
        return typeof(T).IsAssignableFrom(objectType);
    }
}
