using MediatR;

namespace Zone.Core.DNS.Queries
{
    public class GetZonesListQuery : IRequest<GetZonesListResponse>
    {
        public int? Id { get; set; }
    }
}
