using HW21.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.InterfaceServices
{
    public interface IUserService
    {
        Task RegisterUserWithPhoneNumberAsync(long phoneNumber);

        Task AddCarsWithChassisNumberAsync(string chassisNumber);

        Task<List<TakingTurn>> GetActiveTurns();
    }
}
