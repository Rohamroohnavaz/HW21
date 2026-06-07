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
    public class TakingTurnRepository : GenericRepository<TakingTurn> ,ITakingTurnRepository
    {
        public TakingTurnRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<TakingTurn>> GetTurnsByCenterId(int centerId)
        {
            return await _dbContext.TakingTurns
                .AsNoTracking()
                .Where(t => t.CenterId == centerId)
                .ToListAsync();
        }

        public async Task<List<TakingTurn>> GetTurnsByCenterIdAndDate(int centerId, DateTime date)
        {
            return await _dbContext.TakingTurns
                .AsNoTracking()
                .Where(t => t.CenterId == centerId)
                .Where(t => t.CreatedAt == date)
                .ToListAsync();
        }
    }
}
