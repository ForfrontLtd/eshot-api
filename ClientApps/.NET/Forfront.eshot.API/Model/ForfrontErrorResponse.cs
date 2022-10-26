using System.Text.Json.Serialization;

namespace Forfront.eshot.API.Model
{
    public class ForfrontErrorResponse
    {
        [JsonPropertyName("error")]
        public ForfrontError Error { get; set; } = new ForfrontError();
    }
}