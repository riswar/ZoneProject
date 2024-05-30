using Microsoft.EntityFrameworkCore;

namespace Zone.Data.Repository
{
    public class DnsRecordRepository : RepositoryBase<Zone.Domain.DnsRecord>, IDnsRecordRepository
    {
        public DnsRecordRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Domain.DnsRecord>> GetAllZonesAsync()
        {
            return (await FindAll()).OrderBy(x=>x.Fqdn);
        }

        public async Task<Domain.DnsRecord> GetZoneWithDetailsAsync(int id)
        {
            var result = await FindByCondition(zone => zone.Id.Equals(id));
            return await result.FirstOrDefaultAsync();
        }
      
    }
}
