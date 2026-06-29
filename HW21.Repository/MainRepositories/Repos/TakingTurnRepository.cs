using HW21.DomainLayer.Enums;
using HW21.DomainLayer.Models;
using HW21.Infrastructure.Data;
using HW21.Repository.GenericRepositories;
using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Repository.RepoDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Repository.MainRepositories.Repos
{
    public class TakingTurnRepository : GenericRepository<TakingTurn>, ITakingTurnRepository
    {
        public TakingTurnRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TakingTurnDto?> GetByIdTurnDto(int id)
        {
            return await _dbContext.TakingTurns
                .AsNoTracking()
                .Where(t => t.Id == id)
                .Select(x => new TakingTurnDto
                {
                    Id = x.Id,
                    Capacity = x.Capacity,
                    CenterId = x.CenterId,
                    Status = Status.Active
                }).FirstOrDefaultAsync();
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
                .ToListAsync();
        }

        public async Task<TurnByNameDto?> GetTurnByCenterName(string centerName)
        {
            return await _dbContext.TakingTurns
                .AsNoTracking()
                .Where(t => t.Center.Name == centerName)
                .Select(x => new TurnByNameDto
                {
                    ProvinceName = x.ProvinceName,
                    CityName = x.CityName,
                    CenterName = x.Center.Name
                }).FirstAsync();
        }

        public async Task<bool> IsReserveAsync(int timeManagingId)
        {
            return await _dbContext.TakingTurns
                .AsNoTracking()
                .AnyAsync(t => t.TimeId == timeManagingId
                && t.ReserveStatus == ReserveStatus.IsReserve);
        }
    }
}
