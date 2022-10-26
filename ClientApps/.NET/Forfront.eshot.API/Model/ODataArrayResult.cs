using System.Text.Json.Serialization;

namespace Forfront.eshot.API.Model
{
    public class ODataArrayResult<T>
    {
        [JsonPropertyName("odata.context")]
        public string? Metadata { get; set; }

        [JsonPropertyName("value")]
        public T[]? Value { get; set; }
    }
}