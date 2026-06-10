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
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterUserWithPhoneNumberAsync(long phoneNumber)
        {
            await _userRepository.RegistrUserWith(phoneNumber);
        }

        public async Task AddCarsWithChassisNumberAsync(string chassisNumber)
        {
            //Console.Write("Please Enter Your Chassis Number : ");
            //var input = Console.ReadLine();

            var newCar = _userRepository.AddCarWithChassisNumber(chassisNumber);
            await _userRepository.AddCarsAsync(newCar);
        }

        public async Task<List<TakingTurn>> GetActiveTurnsAsync()
        {
            return await _userRepository.GetAcitveTurns();
        }
    }
}
