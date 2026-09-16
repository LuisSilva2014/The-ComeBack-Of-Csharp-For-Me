using AutoManager.Application.Entities;
using AutoManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AutoManager.Application.Services
{
    public class VehicleManagerService : IVehicleRepository
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleManagerService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        ~VehicleManagerService()
        {
            // Deconstructor
        }

        //public ICollection<Car> GetAllByManufacturer(string manufacture)
        //{
        //    var _collection = new Collection<Car>();
        //    return _collection;
        //}


        public ICollection<Car> GetAllByManufacturer(string manufacture)
        {

            return _vehicleRepository.GetAllByManufacturer(manufacture); ;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _vehicleRepository.GetAllAsync(); ;
        }
    }
}
