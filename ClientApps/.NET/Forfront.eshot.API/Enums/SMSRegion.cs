using System.Text.Json.Serialization;

namespace Forfront.eshot.API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SMSRegion
    {
        None = 0,
        UK = 1,
        International = 2,
        US = 3
    }
}