using AutoManager.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoManager.Application.Interfaces
{
    public interface IVehicleService
    {
        public ICollection<Car> GetAllByManufacturer(string manufacture);
        public Task<IEnumerable<Car>> GetAllAsync();
    }
}
