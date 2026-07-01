using HW21.Repository.RepoDto;
using HW21.Service.DtoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.InterfaceServices
{
    public interface ITakingTurnService
    {
        Task CreateTurnForUserById(CreateTurnDto dto, int userId ,int timeManagingId);

        Task CreateTurnForUserByName(TurnByNameDto dto, string provinceName, string cityName);

        Task<List<TurnDto>> GetAllTurnsDto();

        Task<TakingTurnDto?> GetById(int id);

        Task<List<AvailableTurnDto>> GetAvailableTurns(int centerId);
    }
}
