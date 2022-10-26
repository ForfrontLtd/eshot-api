using Forfront.eshot.API.Model;
using System.Net;

namespace Forfront.eshot.API.Exceptions
{
    public class RestApiException : ApplicationException
    {
        public RestApiException(HttpStatusCode code, ForfrontError? error)
        {
            Code = code;
            Details = error;
        }

        public HttpStatusCode Code { get; set; }
        public ForfrontError? Details { get; set; }
    }
}