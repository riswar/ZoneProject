using Zone.Core.Response;

namespace Zone.Core.DNS.Queries
{
    public class GetDnsListResponse : PaginatedResponse<PaginatedList<DnsRecordListVM>>
    {
        public GetDnsListResponse(): base(null,0,0,0)
        {

        }

    }
}
