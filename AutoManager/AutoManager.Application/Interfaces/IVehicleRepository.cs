using AutoManager.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoManager.Application.Interfaces
{
    public interface IVehicleRepository
    {
        public ICollection<Car> GetAllByManufacturer(string manufacture);
        public Task<IEnumerable<Car>> GetAllAsync();
        public Task<Car?> GetByIdAsync(Guid id);
    }
}
