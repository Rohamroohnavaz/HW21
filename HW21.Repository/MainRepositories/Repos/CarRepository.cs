using HW21.DomainLayer.Models;
using HW21.Infrastructure.Data;
using HW21.Repository.GenericRepositories;
using HW21.Repository.MainRepositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Repository.MainRepositories.Repos
{
    public class CarRepository : GenericRepository<Car> ,ICarRepository
    {
        public CarRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ExistByChassissNumber(string chassissNumber)
        {
            return await _dbContext.Cars.AnyAsync(c => c.ChassisNumber == chassissNumber);
        }

        public async Task<List<Car>> GetCarByUserId(int userId)
        {
            return await _dbContext.Cars
                .AsNoTracking()
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }
    }
}
