namespace BaseASP.API.Common
{
    public class APIResponse<T> where T : class
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public APIResponse(bool success, int statusCode, string message, T data)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
        public APIResponse(bool success, int statusCode)
        {
            Success = success;
            StatusCode = statusCode;
        }
    }
}
