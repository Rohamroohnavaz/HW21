using HW21.DomainLayer.Models;
using HW21.Service.DtoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.InterfaceServices
{
    public interface ICarService
    {
        Task<List<CarDto>> GetCarsForUserAsync(int userId);

        Task AddCarAsync(CarDto dto, string userId);

        Task<CarDto?> GetById(int id);
    }
}
