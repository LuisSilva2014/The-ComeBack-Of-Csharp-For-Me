using AutoManager2.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoManager2.Application.Interfaces
{
    public interface IVehicleRepository
    {
        public ICollection<Car> GetAllByManufacturer(string manufacture);
        public Task<IEnumerable<Car>> GetAllAsync();
    }
}
