using AutoMapper;
using MediatR;
using Zone.Core.DNS.Commands.DeleteDNS;
using Zone.Data.Repository;

namespace Zone.Core.DNS.Commands.CreateDNS
{
    public class DeleteDNSCommandHandler : IRequestHandler<DeleteDNSCommand>
    {
        private readonly IDnsRecordRepository _zoneRepository;
        private readonly IMapper _mapper;
        public DeleteDNSCommandHandler(IDnsRecordRepository zoneRepository, IMapper mapper)
        {
            _zoneRepository = zoneRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteDNSCommand request, CancellationToken cancellationToken)
        {
            var dnsRecord = await _zoneRepository.FindByIdAsync(request.Id);
            await _zoneRepository.DeleteAsync(dnsRecord);
        }
    }
}
