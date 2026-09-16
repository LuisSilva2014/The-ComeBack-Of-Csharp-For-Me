using AutoManager.Application.Entities;
using AutoManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AutoManager.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        ~VehicleService()
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
