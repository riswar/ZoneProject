using AutoMapper;
using MediatR;
using Zone.Core.Response;
using Zone.Data.Repository;
using Zone.Domain;

namespace Zone.Core.DNS.Queries
{
    public class GetDnsListQueryHandler// : IRequestHandler<GetZonesListQuery, GetDNSListResponse>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;
        public GetDnsListQueryHandler(IZoneRepository zoneRepository, IMapper mapper)
        {
            _zoneRepository = zoneRepository;
            _mapper = mapper;
        }

        public async Task<GetDnsListResponse> Handle(GetDnsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<DnsRecord> dns= from s in _zoneRepository.RepositoryContext.Dns  
                                       
                                       select s ;
            if (!string.IsNullOrEmpty(request.Fqrs))
                dns.Where(fq => fq.Fqdn.Contains(request.Fqrs));

            if (request.Id>0)
                dns.Where(fq => fq.Id.Equals(request.Id));

            dns.OrderBy(fq => fq.Fqdn);
            var dnsResult = await PaginatedList<DnsRecord>.CreateAsync(dns, (request.Offset==0?0: request.Offset), (request.Limit==0?100: request.Limit));
            //if request
            var dnsList = _mapper.Map<PaginatedList<DnsRecordListVM>>(dnsResult);
            var response = new GetDnsListResponse();
            response.Success= true;
            response.Offset = dnsList.Offset;
            response.Data= dnsList;
            response.Limit = dnsList.Limit;
            response.TotalRecords= dnsList.TotalRecords;
            return response;
        }
    }
}
