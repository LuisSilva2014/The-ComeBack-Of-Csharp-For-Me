using AutoManager.Application.Entities;
using AutoManager.Application.Interfaces;
using AutoManager.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoManager.Infrastructure.Repository
{
    public class VehicleRepository : IVehicleRepository
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

            int pageNumber = 1;
            int pageSize =10;

            pageNumber = Math.Max(1, pageNumber);
            pageSize = Math.Max(1, pageSize);

            return await _dbContext.Cars
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Lets filter using the paging settings
            return  await _dbContext.Cars.ToListAsync(); // return all
        }

        public async Task<Car?> GetByIdAsync(Guid id)
        {
            Car car = await _dbContext.Cars.Where( _=> _.Id == id).FirstOrDefaultAsync();
            return car;
        }


        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            //return await _dbContext.Users.ToListAsync();
            throw new NotImplementedException();
        }

    }
}
