using AutoMapper;
using Moq;
using Zone.Core;
using Zone.Core.DNS.Queries;
using Zone.Data.Repository;
using Zone.UnitTest.Mocks;

namespace Zone.UnitTest.Zones.Queries
{
    public class GetZonesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IZoneRepository> _mockZoneRepository;

        public GetZonesListQueryHandlerTests()
        {
            _mockZoneRepository = RepositoryMock.GetZoneRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task GetZoneListTest()
        {
            //Arrange
            var handler = new GetZonesListQueryHandler(_mockZoneRepository.Object,_mapper);

            //Act
            var result = await handler.Handle(new GetZonesListQuery(), CancellationToken.None);

            //Assert
            Assert.Equal(result.Data.Count, 2);
           
        }
    }
}
