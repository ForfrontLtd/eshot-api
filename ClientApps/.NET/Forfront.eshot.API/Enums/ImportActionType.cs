using System.Text.Json.Serialization;

namespace Forfront.eshot.API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ImportActionType
    {
        Import = 1,
        Repopulate = 2,
        Unsubscribe = 3,
    }
}