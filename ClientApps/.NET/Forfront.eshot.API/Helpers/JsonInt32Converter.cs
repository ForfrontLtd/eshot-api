using System.Text.Json;
using System.Text.Json.Serialization;

namespace Forfront.eshot.API.Helpers
{
    public class JsonInt32Converter : JsonConverter<int>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(int);
        }

        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return reader.GetInt32();
            }
            catch
            {
                return 0;
            }
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}