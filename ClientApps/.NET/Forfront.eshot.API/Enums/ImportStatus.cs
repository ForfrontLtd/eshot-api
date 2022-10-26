using System.Text.Json.Serialization;

namespace Forfront.eshot.API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ImportStatus
    {
        Waiting = 1,
        Error = 2,
        Success = 3
    }
}