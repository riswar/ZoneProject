using AutoMapper;
using MediatR;
using Zone.Data.Repository;
using Zone.Domain;

namespace Zone.Core.DNS.Commands.CreateDNS
{
    public class CreateDNSCommandHandler : IRequestHandler<CreateDNSCommand, CreateDNSCommandResponse>
    {
        private readonly IDnsRecordRepository _dnsRepository;
        private readonly IZoneRepository _zoneRepository;

        private readonly IMapper _mapper;
        public CreateDNSCommandHandler(IDnsRecordRepository dnsRepository, IZoneRepository zoneRepository, IMapper mapper)
        {
            _dnsRepository = dnsRepository;
            _zoneRepository = zoneRepository;
            _mapper = mapper;
        }

        public async Task<CreateDNSCommandResponse> Handle(CreateDNSCommand request, CancellationToken cancellationToken)
        {
            var dns = _mapper.Map<DnsRecord> (request);
            var response = new CreateDNSCommandResponse();

            //Move this to Fluent validation 
            var validation = await _zoneRepository.FindByIdAsync(request.Zone);
            if (validation == null)
            {
                response.Success = false;
                string errorMessage = $"The zone does not exists in the system!";
                response.ValidationErrors = new List<string>() { errorMessage };
                return response;
            }

            //Merge below two validation together during refactor
            var validation2 = await _dnsRepository.FindByCondition(filter => filter.Zone == request.Zone && filter.Fqdn.Equals(request.Fqdn, StringComparison.InvariantCultureIgnoreCase) && filter.Type.Equals(request.Type, StringComparison.InvariantCultureIgnoreCase));
            if (validation2 != null && validation2.Count() !=0)
            {
                response.Success = false;
                string errorMessage = $"The combination of Fqdn and record type already exist in the system!";
                response.ValidationErrors = new List<string>() { errorMessage };
                return response;
            }

            var validation3 = await _dnsRepository.FindByCondition(filter => filter.Zone == request.Zone);
            if (validation3 != null && validation3.Count() >= 10)
            {
                response.Success = false;
                string errorMessage = $"You cannot add more than 10 records for a zone!";
                response.ValidationErrors = new List<string>() { errorMessage };
                return response;
            }

            //Below line is not needed for regular database as it is set through identity column
            dns.Id = (await _dnsRepository.FindAll()).Count() + 1;


            dns = await _dnsRepository.CreateAsync(dns);
            response.DNS = _mapper.Map<CreateDNSDto>(dns);
            return response;
        }
    }
}
