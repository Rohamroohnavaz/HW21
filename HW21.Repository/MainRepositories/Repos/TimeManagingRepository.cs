using HW21.DomainLayer.Models;
using HW21.Infrastructure.Data;
using HW21.Repository.GenericRepositories;
using HW21.Repository.MainRepositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Repository.MainRepositories.Repos
{
    public class TimeManagingRepository : GenericRepository<TimeManaging> ,ITimeManagingRepository
    {
        protected TimeManagingRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<TimeManaging>> GetAllTimesByCenterId(int centerId)
        {
            return await _dbContext.Times
                .AsNoTracking()
                .Where(t => t.CenterId == centerId)
                .ToListAsync();
        }
    }
}
