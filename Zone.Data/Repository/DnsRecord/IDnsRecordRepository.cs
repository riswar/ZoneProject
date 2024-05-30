namespace Zone.Data.Repository
{
    public interface IDnsRecordRepository : IRepositoryBase<Zone.Domain.DnsRecord>
    {
        Task<IEnumerable<Zone.Domain.DnsRecord>> GetAllZonesAsync();
        Task<Zone.Domain.DnsRecord> GetZoneWithDetailsAsync(int id);
    }
}
