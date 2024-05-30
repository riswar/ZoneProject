namespace Zone.Core.Response
{
    public class BaseResponse
    {
        public BaseResponse() { Success = true; }
        public BaseResponse(string message)
        {
            Success = true;
            Message = message;            
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
