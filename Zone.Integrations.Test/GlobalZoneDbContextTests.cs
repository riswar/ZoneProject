using Microsoft.EntityFrameworkCore;
using Zone.Data;
using Zone.Data.Repository;
using Zone.Domain;

namespace Zone.Integrations.Test
{
    public class GlobalZoneDbContextTests
    {
        private readonly RepositoryContext _repositoryContext;
        IZoneRepository _zoneRepository;

        public GlobalZoneDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<RepositoryContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _repositoryContext = new RepositoryContext(dbContextOptions);
            _zoneRepository = new ZoneRepository(_repositoryContext);
        }

        [Fact]
        public async void Save_Zone_Success()
        {
            //Arrange
            var zone = new ZoneRecord()
            {
                Id = 1,
                Name="test.com"

            };
            //Act
            await _zoneRepository.CreateAsync(zone);

            //Assert
            Assert.Equal((await _zoneRepository.FindByIdAsync(1)).Id, zone.Id);
        }
    }
}