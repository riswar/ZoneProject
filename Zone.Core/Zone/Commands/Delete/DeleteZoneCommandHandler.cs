using MediatR;
using Zone.Data.Repository;

namespace Zone.Core.Zone.Commands.Delete
{
    public class DeleteZoneCommandHandler : IRequestHandler<DeleteZoneCommand>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IDnsRecordRepository _dnsRecordRepository;

        public DeleteZoneCommandHandler(IZoneRepository zoneRepository, IDnsRecordRepository dnsRecordRepository)
        {
            _zoneRepository = zoneRepository;
            _dnsRecordRepository = dnsRecordRepository;
        }
        public async Task Handle(DeleteZoneCommand request, CancellationToken cancellationToken)
        {
            //Refactor below two lines if possible - Delete associated DNS records
            var dnsRecords = await _dnsRecordRepository.FindByCondition(q => q.Zone.Equals(request.Id));
            if (dnsRecords.Count() >0)
                _dnsRecordRepository.RepositoryContext.RemoveRange(dnsRecords);

            var dnsRecord = await _zoneRepository.FindByIdAsync(request.Id);
            await _zoneRepository.DeleteAsync(dnsRecord);
        }
    }
}
