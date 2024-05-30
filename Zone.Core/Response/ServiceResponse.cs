namespace Zone.Core.Response
{
    public class ServiceResponse<T> : BaseResponse
    {
        public ServiceResponse(T data)
        {
            Data=data;
        }
        public T Data { get; set; }
    }
}
