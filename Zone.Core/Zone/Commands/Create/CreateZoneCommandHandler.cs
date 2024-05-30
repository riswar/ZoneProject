using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zone.Data.Repository;
using Zone.Domain;

namespace Zone.Core.Zone.Commands.Create
{
    public class CreateZoneCommandHandler : IRequestHandler<CreateZoneCommand, CreateZoneCommandResponse>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;
        public CreateZoneCommandHandler(IZoneRepository zoneRepository, IMapper mapper)
        {
            _zoneRepository = zoneRepository;
            _mapper = mapper;
        }

        public async Task<CreateZoneCommandResponse> Handle(CreateZoneCommand request, CancellationToken cancellationToken)
        {
            var dns = _mapper.Map<ZoneRecord> (request);
            var response = new CreateZoneCommandResponse();

            //Move this to Fluent validation 
            var result = await _zoneRepository.FindByCondition(req => req.Name.Equals(request.Name, StringComparison.InvariantCultureIgnoreCase));
            var totalRecords = await result.CountAsync();
            if (totalRecords>0)
            {
                response.Success = false;
                string errorMessage = $"The zone ({request.Name}) already exists in the system!";
                response.ValidationErrors = new List<string>() { errorMessage };
                return response;
            }

            //Below line is not needed for regular database
            dns.Id = (await _zoneRepository.FindAll()).Count() + 1;

            //Perform validation here
            dns = await _zoneRepository.CreateAsync(dns);
            response.Zone  = _mapper.Map<CreateZoneDto>(dns);
            return response;
        }
    }
}
