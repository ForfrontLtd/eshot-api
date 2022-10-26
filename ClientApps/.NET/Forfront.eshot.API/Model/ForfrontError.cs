using System.Text.Json.Serialization;

namespace Forfront.eshot.API.Model
{
    public class ForfrontError
    {
        /// <summary>
        /// This is a coding handle for you to use to handle different types of exceptions thrown from the API
        /// See the documentation for more information
        /// </summary>
        [JsonPropertyName("code")]
        public int? Code { get; set; }

        /// <summary>
        /// The error message
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// The HTTP Status Code
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        /// Some errors return 1 or more errors in a model state array
        /// </summary>
        [JsonPropertyName("modelState")]
        public dynamic? ModelState { get; set; }
    }
}