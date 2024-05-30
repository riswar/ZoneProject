using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zone.ViewModel;

namespace TestClient.Data
{
    public class TestClientContext : DbContext
    {
        public TestClientContext (DbContextOptions<TestClientContext> options)
            : base(options)
        {
        }

        public DbSet<Zone.ViewModel.DnsRecordListVM> DnsRecordListVM { get; set; } = default!;
    }
}
