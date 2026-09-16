using AutoManager.Application.Entities;
using AutoManager.Application.Interfaces;
using AutoManager.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoManager.Infrastructure.Repository
{
    internal class VehicleRepository : IVehicleRepository
    {

        private VehicleManagerContext _dbContext;


        public VehicleRepository(VehicleManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Car> GetAllByManufacturer(string manufacture)
        {

            ICollection<Car> result  = _dbContext.Cars.Where(t => t.Manufacturer.Contains(manufacture)).ToList();
           return result;
        }

        public async Task<IEnumerable<Car>> GetAllAsync() {
            return  await _dbContext.Cars.ToListAsync();
        }  


        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            //return await _dbContext.Users.ToListAsync();
            throw new NotImplementedException();
        }

    }
}
