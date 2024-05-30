using AutoMapper;
using MediatR;
using Zone.Data.Repository;
using Zone.Domain;

namespace Zone.Core.DNS.Queries
{    
    public class GetZonesListQueryHandler : IRequestHandler<GetZonesListQuery, GetZonesListResponse>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IMapper _mapper;
        public GetZonesListQueryHandler(IZoneRepository zoneRepository, IMapper mapper)
        {
            _zoneRepository = zoneRepository;
            _mapper = mapper;
        }

        public async Task<GetZonesListResponse> Handle(GetZonesListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ZoneRecord> zone;
            if (request.Id !=null && request.Id>0)
                zone = await _zoneRepository.FindByCondition(q => q.Id == request.Id);
            else
                zone = await _zoneRepository.GetAllZonesAsync();

            var result = _mapper.Map<List<ZoneRecordListVM>>(zone);
            var response = new GetZonesListResponse();
            response.Data = result.ToList();
            return response;
        }
    }
}
