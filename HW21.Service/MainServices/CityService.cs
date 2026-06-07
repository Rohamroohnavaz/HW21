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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        //7
        public async Task<List<CityDto>> GetAllCitiesOfProvinceService(int provinceId)
        {
            var cities = await _cityRepository.GetCityByProvinceId(provinceId);

            return cities.Select(x => new CityDto
            {
                Id = x.Id,
                Name = x.Name,
                ProvinceId = x.ProvinceId
            }).ToList();
        }
    }
}
