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
    public class CenterService : ICenterService
    {
        private readonly ICenterRepository _centerRepository;

        public CenterService(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }

        public async Task<List<CenterDto>> GetActiveCenterByCityIdAsync(int cityId)
        {
            var centers = await _centerRepository.GetActiveCenters(cityId);

            return centers
                .Where(c => c.Status == Status.Active)
                .Select(x => new CenterDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CityId = x.CityId,
                    Status = x.Status,
                }).ToList();
        }

        public async Task<GetCenterDto?> GetById(int id)
        {
            var center = await _centerRepository.GetByIdAsync(id);

            return new GetCenterDto
            {
                Id = center.Id,
                Name = center.Name,
                CityId = center.CityId,
                TurnCount = center.TurnCount,
                Address = center.Address,
                Status = center.Status
            };
        }
    }
}
