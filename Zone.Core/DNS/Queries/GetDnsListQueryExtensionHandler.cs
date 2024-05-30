using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.Linq;
using Zone.Core.Response;
using Zone.Data.Repository;
using Zone.Domain;

namespace Zone.Core.DNS.Queries
{
    /// <summary>
    /// Please note this is not needed for regular database as 
    /// It is implemented to support where clause usage in-memory database
    /// </summary>
    public class GetInMemoryZonesListQueryHandler : IRequestHandler<GetDnsListQuery, GetDnsListResponse>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;
        public GetInMemoryZonesListQueryHandler(IZoneRepository zoneRepository, IMapper mapper)
        {
            _zoneRepository = zoneRepository;
            _mapper = mapper;
        }

        public async Task<GetDnsListResponse> Handle(GetDnsListQuery request, CancellationToken cancellationToken)
        {


            IEnumerable<DnsRecordListVM> dns = from d in _zoneRepository.RepositoryContext.Dns
                                               join z in _zoneRepository.RepositoryContext.Zones on d.Zone equals z.Id
                                               select new DnsRecordListVM() { Id = d.Id, Data = d.Data, Zone = z.Name, Fqdn = d.Fqdn, RecordName = d.RecordName, Ttl = d.Ttl, Type = d.Type, ZoneId = z.Id };


            if (!string.IsNullOrEmpty(request.Fqrs))
                dns = dns.Where(d => d.Zone.Contains(request.Fqrs));

            if (request.Id > 0)
                dns = dns.Where(d => d.Id.Equals(request.Id));
            if(request.ZoneId > 0)
                dns = dns.Where(d => d.ZoneId.Equals(request.ZoneId));

            if (!string.IsNullOrEmpty(request.OrderByField) && request.OrderByField.Equals("zone", StringComparison.OrdinalIgnoreCase))
            {
                

                    if (!string.IsNullOrEmpty(request.OrderBy) && request.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase))
                        dns = dns.OrderByDescending(d => d.Zone);
                    else
                        dns = dns.OrderBy(d => d.Zone);
                
            }
            if (!string.IsNullOrEmpty(request.OrderByField) && request.OrderByField.Equals("fqdn", StringComparison.OrdinalIgnoreCase))
            {

                if (!string.IsNullOrEmpty(request.OrderBy) && request.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase))
                    dns = dns.OrderByDescending(d => d.Fqdn);
                else
                    dns = dns.OrderBy(d => d.Fqdn);

            }



            var dnsResult = PaginatedList<DnsRecordListVM>.Create(dns, (request.Offset == 0 ? 0 : request.Offset), (request.Limit == 0 ? 100 : request.Limit));
            //if request
            //var dnsList = _mapper.Map<PaginatedList<DnsRecordListVM>>(dnsResult);
            var response = new GetDnsListResponse();
            response.Success = true;
            response.Offset = dnsResult.Offset;
            response.Data = dnsResult;
            response.Limit = dnsResult.Limit;
            response.TotalRecords = dnsResult.TotalRecords;
            return response;
        }
    }
}
