using System.Text.Json.Serialization;

namespace Forfront.eshot.API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ImportType
    {
        SOAP = 1,
        REST = 2,
        Manual = 3
    }
}