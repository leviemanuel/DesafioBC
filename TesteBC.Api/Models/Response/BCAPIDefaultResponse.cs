using System.Net;

namespace TesteBC.Api.Models.Response
{
    public class BCAPIDefaultResponse<T>
    {
        public bool FlSuccess { get; set; } = true;
        public string ErrorMessage { get; set; } = string.Empty;
        public HttpStatusCode StatusCode { get; set; }
        public T? Result { get; set; }

        public BCAPIDefaultResponse(HttpStatusCode statusCode, T? result)
        {
            StatusCode = statusCode;
            Result = result;
        }
        public BCAPIDefaultResponse(HttpStatusCode statusCode, Exception ex)
        {
            StatusCode = statusCode;
            FlSuccess = false;
            ErrorMessage = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
        }
        public BCAPIDefaultResponse(HttpStatusCode statusCode, string error)
        {
            StatusCode = statusCode;
            FlSuccess = false;
            ErrorMessage = error;
        }
    }
}
