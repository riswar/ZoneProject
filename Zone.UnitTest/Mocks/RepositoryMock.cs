using Moq;
using Zone.Data.Repository;
using Zone.Domain;

namespace Zone.UnitTest.Mocks
{
    public  class RepositoryMock
    {
        public static Mock<IZoneRepository> GetZoneRepository()
        {
            
            var zones = new List<ZoneRecord>
            {
                new ZoneRecord
                {
                    Id = 1,
                    Name = "devselect.com"
                },
                new ZoneRecord
                {
                    Id = 1,
                    Name = "microsoft.com"
                }
            };

            var mocZoneRepo = new Mock<IZoneRepository>();
            mocZoneRepo.Setup(repo => repo.GetAllZonesAsync()).ReturnsAsync(zones);

            mocZoneRepo.Setup(repo => repo.CreateAsync(It.IsAny<ZoneRecord>())).ReturnsAsync(
                (ZoneRecord zone) =>
                {
                    zones.Add(zone);
                    return zone;
                });
            return mocZoneRepo;
        }
    }
}
