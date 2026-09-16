using AutoManager.Application.Entities;
using AutoManager.Application.Interfaces;
using AutoManager.Application.Services;
using Moq;

namespace AutoManager.Tests
{
    public class VehicleTests
    {
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
