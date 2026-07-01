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
    public interface ITakingTurnRepository : IGenericRepository<TakingTurn>
    {
        Task<List<TakingTurn>> GetTurnsByCenterId(int centerId);

        Task<List<TakingTurn>> GetTurnsByCenterIdAndDate(int centerId, DateTime date);

        Task<bool> IsReserveAsync(int timeManagingId);

        Task<TakingTurnDto?> GetByIdTurnDto(int id);

        //Task<bool> CheckAvailableTurns(int timeId, string provinceName);

        //Task<List<TakingTurn>> GetTurnsByName(string provinceName, string cityName, string centerName);

        Task<TurnByNameDto?> GetTurnByCenterName(string centerName);

        Task<List<TakingTurn>> GetAvailableTurns(int centerId);
    }
}
