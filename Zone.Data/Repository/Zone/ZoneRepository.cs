using Microsoft.EntityFrameworkCore;

namespace Zone.Data.Repository
{
    public class ZoneRepository : RepositoryBase<Zone.Domain.ZoneRecord>, IZoneRepository
    {
        public ZoneRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Domain.ZoneRecord>> GetAllZonesAsync()
        {
            return (await FindAll()).OrderBy(x=>x.Name);
        }

        public async Task<Domain.ZoneRecord> GetZoneWithDetailsAsync(int id)
        {
            var result = await FindByCondition(zone => zone.Id.Equals(id));
            return await result.FirstOrDefaultAsync();
        }      
    }
}
