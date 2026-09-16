using AutoManager.Application.Entities;
using AutoManager.Application.Interfaces;
using AutoManager.Application.Services;
using Moq;

namespace AutoManager.Tests
{
    public class VehicleTests
    {
        //Test #1: Vehicle Exists
        //Purpose: Verify the service returns a vehicle when found.
        [Fact]
        public async Task GetByIdAsync_WhenVehicleExists_ReturnsVehicle()
        {
            var id = Guid.NewGuid();
            var car = new Car
            {
                Id = id,
                Manufacturer = "Toyota"
            };
            var repositoryMock = new Mock<IVehicleRepository>();
            repositoryMock
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(car); // Mock setup
            var service = new VehicleService(repositoryMock.Object);
            //Act 
            var result = await service.GetByIdAsync(id);
            //Asserts
            Assert.NotNull(result);
            Assert.Equal(id, result!.Id);
        }

        //Test #2: Vehicle Does Not Exist
          //Purpose: Verify the service returns null when not found.
        [Fact]
        public async Task GetByIdAsync_WhenVehicleDoesNotExist_ReturnsNull()
        {
            var id = Guid.NewGuid();
            var repositoryMock = new Mock<IVehicleRepository>();
            repositoryMock
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync((Car?)null); // Mock setup
            var service = new VehicleService(repositoryMock.Object); 
            //Act
            var result = await service.GetByIdAsync(id);
            //Asserts
            Assert.Null(result);
        }

        //Test #3: Repository Is Called Once
        //Purpose: Verify the service is actually calling the repository.
        [Fact]
        public async Task GetByIdAsync_CallsRepositoryOnce()
        {
            // Arrange
            var id = Guid.NewGuid();
            var car = new Car { Id = id, Manufacturer = "Honda" };

            var repositoryMock = new Mock<IVehicleRepository>(); // Mock setup
            repositoryMock
                .Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(car);
            var service = new VehicleService(repositoryMock.Object);
            // Act
            await service.GetByIdAsync(id);
            // Assert
            repositoryMock.Verify(x => x.GetByIdAsync(id), Times.Once);
        }
    }
}
