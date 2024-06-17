
namespace MilkCoffeeAPI.Core
{
    public class APIResponse<T>
    {
        public int StatusCodes { get; set; }
        public string Message { get; set; } = string.Empty;

        public bool Success { get; set; }

        public T? Data { get; set; }

        public void ToFailedResponse(string message, int statuscode)
        {
            Success = false;
            Message = message;
            StatusCodes = statuscode;
        }

        public void ToSuccessResponse(string message, int statuscode)
        {
            Success = true;
            Message = message;
            StatusCodes = statuscode;
        }

        public void ToSuccessResponse(T data, string message, int statuscode)
        {
            Success = true;
            Message = message;
            Data = data;
            StatusCodes = statuscode;
        }
    }
    public class APIResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public void ToFailedResponse(string message)
        {
            Success = false;
            Message = message;
        }
        public void ToSuccessResponse(string message)
        {
            Success = true;
            Message = message;
        }
    }
}
