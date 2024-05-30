namespace Zone.Core.Response
{
    public class PaginatedResponse<T> : BaseResponse
    {
        public PaginatedResponse(T data, int offset, int limit, int totalRecords)
        {
            Data=data;
            Offset = offset;
            Limit = limit;
            TotalRecords = totalRecords;
        }
        public int TotalRecords { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        public T Data { get; set; }
    }
}
