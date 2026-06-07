using HW21.DomainLayer.Enums;
using HW21.DomainLayer.Models;
using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Service.DtoServices;
using HW21.Service.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.MainServices
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task AddCarAsync(CarDto dto, string userId)
        {
            var existCar = await _carRepository.ExistByChassissNumber(dto.ChassisNumber);

            if(existCar)
                Console.WriteLine("Car is exist !!Select another one!");

            var car = new Car
            {
                Id = dto.Id,
                ChassisNumber = dto.ChassisNumber,
                Status = Status.Active,
            };

            await _carRepository.AddAsync(car);

            Console.WriteLine("Car Added Successfully:))");
        }

        public async Task<List<CarDto>> GetCarsForUserAsync(int userId)
        {
            var cars = await _carRepository.GetCarByUserId(userId);

            return cars.Select(x => new CarDto          
            {
                Id = x.Id,
                ChassisNumber = x.ChassisNumber,
                Status = x.Status
            }).ToList();
        }
    }
}
