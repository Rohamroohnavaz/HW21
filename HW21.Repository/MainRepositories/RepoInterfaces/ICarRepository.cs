using HW21.DomainLayer.Models;
using HW21.Repository.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Repository.MainRepositories.RepoInterfaces
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<List<Car>> GetCarByUserId(int userId);

        Task<bool> ExistByChassissNumber(string chassissNumber);
    }
}
