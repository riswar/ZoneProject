using AutoMapper;
using MediatR;
using Zone.Core.DNS.Commands.UpdateDNS;
using Zone.Core.Response;
using Zone.Data.Repository;
using Zone.Domain;

namespace Zone.Core.DNS.Commands.CreateDNS
{
    public class UpdateDNSCommandHandler : IRequestHandler<UpdateDNSCommand, BaseResponse>
    {
        private readonly IDnsRecordRepository _dnsRepository;
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;
        public UpdateDNSCommandHandler(IDnsRecordRepository dnsRepository, IZoneRepository zoneRepository, IMapper mapper)
        {
            _dnsRepository = dnsRepository;
            _zoneRepository = zoneRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateDNSCommand request, CancellationToken cancellationToken)
        {
            var dns = _mapper.Map<DnsRecord>(request);
            var response = new BaseResponse();

            //Perform Data Validation


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
            var validation2 = await _dnsRepository.FindByCondition(filter => filter.Zone == request.Zone && filter.Id != request.Id && filter.Fqdn.Equals(request.Fqdn, StringComparison.InvariantCultureIgnoreCase) && filter.Type.Equals(request.Type, StringComparison.InvariantCultureIgnoreCase));
            if (validation2 != null && validation2.Count() != 0)
            {
                response.Success = false;
                string errorMessage = $"The combination of Fqdn and record type already exist in the system!";
                response.ValidationErrors = new List<string>() { errorMessage };
                return response;
            }

            await _dnsRepository.UpdateAsync(dns);
            return response;
        }
    }
}
