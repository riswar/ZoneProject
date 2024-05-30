using Microsoft.EntityFrameworkCore;

namespace Zone.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Zone.Domain.DnsRecord> Dns { get; set; }
        public DbSet<Zone.Domain.ZoneRecord> Zones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Override mapping or constraints if needed
        }        
    }
}
