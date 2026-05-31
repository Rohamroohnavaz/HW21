using HW21.DomainLayer.Enums;
using HW21.DomainLayer.Models;
using HW21.Infrastructure.Data;
using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Repository.MainRepositories.Repos;
using HW21.Service.InterfaceServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.MainServices
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepository;

        public UserService(AppDbContext context ,IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task RegisterUserWithPhoneNumberAsync(long phoneNumber)
        {
            await _context.Set<User>().FirstOrDefaultAsync(u => u.Role == Role.NormalUser);

            var register = await _context.Set<User>()
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

            if (register is null)
                return;

            Console.WriteLine("User Registered Successfully!!");
        }

        public async Task AddCarsWithChassisNumberAsync(string chassisNumber)
        {
            Console.Write("Please Enter Your Chassis Number : ");
            var input = Console.ReadLine();

            var newCar = await _context.Set<Car>()
                .Where(n => input == n.ChassisNumber)
                .FirstAsync();

            await _userRepository.AddCarsAsync(newCar);
        }

        public async Task<List<TakingTurn>> GetActiveTurns()
        {
            var turns = await _context.Set<TakingTurn>()
                .AsNoTracking()
                .Where(t => t.Status == Status.Active)
                .ToListAsync();

            return turns;
        }
    }
}
