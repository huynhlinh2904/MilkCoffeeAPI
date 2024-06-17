namespace MilkCoffeeAPI.Core
{
    public class ApiResponseListError
    {
        public bool Success { get; set; } = true;
        public string Note { get; set; } = string.Empty;
        public List<string> Messages { get; set; }
        public void ToFailedReponseError()
        {
            Messages = new List<string>();
        }
        public void ToFailedResponse(List<string> errors)
        {
            Success = false;
            Messages = errors;
        }

        public void ToSuccessResponse(string message)
        {
            Success = true;
            Messages = new List<string>();
        }
    }
}
