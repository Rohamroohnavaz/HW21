using HW21.DomainLayer.Enums;
using HW21.DomainLayer.Models;
using HW21.Infrastructure.Data;
using HW21.Infrastructure.Data.Seed_Data;
using HW21.Repository.GenericRepositories;
using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Repository.RepoDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Repository.MainRepositories.Repos
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Car?> AddCarWithChassisNumber(string chassisNumber)
        {
            var car = await _dbContext.Cars
                 .AsNoTracking()
                 .Where(c => c.ChassisNumber == chassisNumber)
                 .FirstAsync();

            return car;
        }

        public async Task AddCarsAsync(Task<Car?> entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RegistrUserWith(long phoneNumber)
        {
            await _dbContext.Users
               .FirstOrDefaultAsync(u => u.Role == Role.NormalUser);

            var user = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

            if (user == null)
                return;

            Console.WriteLine("User Successfully Registered!");
        }

        public async Task<List<TakingTurn>> GetAcitveTurns()
        {
            var activeTurns = await _dbContext.TakingTurns
                 .AsNoTracking()
                 .Where(t => t.Status == Status.Active)
                 .ToListAsync();

            if (!activeTurns.Any())
                throw new Exception("Not Found Active Turns !!");

            return activeTurns;
        }

        //public Task<TakingTurnDto> TakeTurnFromCenterForCar(string provinceName ,string cityName ,string centerName)
        //{
        //    var centers = SeedData.CreateCenter;

        //    if (!centers.Any())
        //        return null;

            
        //}
    }
}
