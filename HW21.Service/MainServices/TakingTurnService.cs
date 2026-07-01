using HW21.DomainLayer.Enums;
using HW21.DomainLayer.Models;
using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Repository.RepoDto;
using HW21.Service.DtoServices;
using HW21.Service.InterfaceServices;
using HW21.Service.MainServices.Redis;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HW21.Service.MainServices
{
    public class TakingTurnService : ITakingTurnService
    {
        private readonly ITakingTurnRepository _turnRepository;
        private readonly ICarRepository _carRepository;
        private readonly ICenterRepository _centerRepository;
        private readonly IDistributedCache _cache;
        private readonly IRedisService _redisService;

        public TakingTurnService(
              ITakingTurnRepository turnRepository
            , ICarRepository carRepository
            , ICenterRepository centerRepository
            , IDistributedCache cache
            , IRedisService redisService)
        {
            _turnRepository = turnRepository;
            _carRepository = carRepository;
            _centerRepository = centerRepository;
            _cache = cache;
            _redisService = redisService;
        }

        public async Task CreateTurnForUserById(CreateTurnDto dto, int userId, int timeManagingId)
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

        public async Task CreateTurnForUserByName(TurnByNameDto dto, string provinceName, string cityName)
        {
            var turn = await _turnRepository.GetTurnByCenterName(dto.CenterName);
            if (turn.ProvinceName != provinceName && turn.CityName != cityName)
            {
                Console.WriteLine("Invalid Names !!");
                return;
            }
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

        public async Task<List<AvailableTurnDto>> GetAvailableTurns(int centerId)
        {
            var cacheKey = $"TakingTurn:{centerId}";

            var cachedTakingTurns = await _redisService.GetAsync<List<AvailableTurnDto>>(cacheKey);

            if (cachedTakingTurns is not null)
                return cachedTakingTurns;

            var takingTurns = await _turnRepository.GetAvailableTurns(centerId);

            var result = takingTurns.Select(x => new AvailableTurnDto
            {
                Id = x.Id,
                Capacity = x.Capacity,
                CenterId = x.CenterId,
                CityName = x.CityName,
                Status = Status.Active
            }).ToList();

            await _redisService.SetAsync(cacheKey, result ,TimeSpan.FromMinutes(5));

            return result;
        }

        public async Task<TakingTurnDto?> GetById(int id)
        {
            return await _turnRepository.GetByIdTurnDto(id);
        }
    }
}
