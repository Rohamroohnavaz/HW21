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
    public class TakingTurnService : ITakingTurnService
    {
        private readonly ITakingTurnRepository _turnRepository;
        private readonly ICarRepository _carRepository;
        private readonly ICenterRepository _centerRepository;

        public TakingTurnService(ITakingTurnRepository turnRepository 
            ,ICarRepository carRepository ,ICenterRepository centerRepository)
        {
            _turnRepository = turnRepository;
            _carRepository = carRepository;
            _centerRepository = centerRepository;
        }

        public async Task CreateTurnForUser(CreateTurnDto dto, int userId ,int timeManagingId)
        {
            var car = await _carRepository.GetByIdAsync(dto.CarId);
            if (car is null || car.UserId == userId)
            {
                Console.WriteLine("Car Is Invalid !!");
                return;
            }
                

            var center = _centerRepository.GetByIdAsync(dto.CenterId);
            if (center is null || (int)center.Status == (int)Status.InActive)
            {
                Console.WriteLine("Center Is Invalid !!");
                return;
            }
             
            var turns = await _turnRepository.IsReserveAsync(timeManagingId);
            if (turns)
            {
                Console.WriteLine("This Turn Already Reserved!!");
                return;
            }

            var newTurn = new TakingTurn
            {
                CenterId = dto.CenterId,
                CarId = dto.CarId,
                ReserveStatus = ReserveStatus.IsReserve
            };

            await _turnRepository.AddAsync(newTurn);
        }

        public async Task<List<TurnDto>> GetAllTurnsDto()
        {
            var turns = await _turnRepository.GetAllAsync();

            return turns.Select(x => new TurnDto
            {
                Id = x.Id,
                Capacity = x.Capacity,
                CenterId = x.CenterId,
                Status = Status.Active
            }).ToList();
        }
    }
}
