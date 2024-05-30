namespace Zone.Data.Repository
{
    public interface IZoneRepository : IRepositoryBase<Zone.Domain.ZoneRecord>
    {
        Task<IEnumerable<Zone.Domain.ZoneRecord>> GetAllZonesAsync();
        Task<Zone.Domain.ZoneRecord> GetZoneWithDetailsAsync(int id);
    }
}
