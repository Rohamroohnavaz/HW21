using HW21.DomainLayer.Models;
using HW21.Repository.GenericRepositories;
using HW21.Repository.RepoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Repository.MainRepositories.RepoInterfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task AddCarsAsync(Task<Car?> entity);

        Task RegistrUserWith(long phoneNumber);

        Task<Car?> AddCarWithChassisNumber(string chassisNumber);

        Task<List<TakingTurn>> GetAcitveTurns();

        //Task<TakingTurnDto> TakeTurnFromCenterForCar(string provinceName ,string cityName ,string centerName);
    }
}
