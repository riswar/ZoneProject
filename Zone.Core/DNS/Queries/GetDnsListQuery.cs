using MediatR;

namespace Zone.Core.DNS.Queries
{
    public class GetDnsListQuery : IRequest<GetDnsListResponse>
    {
        public string? Fqrs { get; set; }
        public int? ZoneId { get; set; }

        public int? Id { get; set; }

        public int Offset { get; set; }
        public int Limit { get; set; }
        public string?    OrderBy { get; set; }
        public string? OrderByField { get; set; }

    }
}
