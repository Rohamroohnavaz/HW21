using HW21.DomainLayer.Models;
using HW21.Repository.GenericRepositories;
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
    }
}
