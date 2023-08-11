using Newtonsoft.Json;
using System.Net;

namespace TesteBC.Web.Models
{
    public class APIResponse<T>
    {
        [JsonProperty("flSuccess")]
        public bool FlSuccess { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; } = string.Empty;

        [JsonProperty("statusCode")]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }
    }
}