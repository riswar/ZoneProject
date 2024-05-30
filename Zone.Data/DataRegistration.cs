using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Zone.Data.Repository;

namespace Zone.Data
{
    public static class DataRegistration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services) {
            
            services.AddDbContext<RepositoryContext>(config =>
            {
                config.UseInMemoryDatabase("ZoneDatabase")                                
                                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                                 .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                                 .EnableSensitiveDataLogging();                
            });
            services.AddScoped<IZoneRepository, ZoneRepository>();
            services.AddScoped<IDnsRecordRepository, DnsRecordRepository >();
            return services;
        }
    }
}
