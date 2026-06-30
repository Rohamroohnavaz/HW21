using HW21.DomainLayer.Models;
using HW21.Service.DtoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.InterfaceServices
{
    public interface IUserService
    {
        Task<int> RegisterUserWithInformationAsync(string username ,string password ,long phoneNumber);

        Task<Car?> AddCarsWithChassisNumberAsync(string chassisNumber);

        Task<List<TakingTurn>> GetActiveTurnsAsync();

        Task UpdateUserInfo(UserDto dto ,int id);
    }
}
