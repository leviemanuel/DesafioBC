using Newtonsoft.Json;
using System.Net;

namespace TesteBC.Web.Models
{
    public class ErrorDetailModel
    {
        [JsonProperty("flSuccess")]
        public bool FlSuccess { get; set; } = false;

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; } = string.Empty;

        [JsonProperty("httpStatusCode")]
        public HttpStatusCode StatusCode { get; set; }

        public ErrorDetailModel(string _errorMessage, HttpStatusCode _statusCode)
        {
            ErrorMessage = _errorMessage;
            StatusCode = _statusCode;
        }
    }
}
