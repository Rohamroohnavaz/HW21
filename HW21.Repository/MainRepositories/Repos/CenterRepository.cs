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
    public class CenterRepository : GenericRepository<TechnicalExaminationCenter>, ICenterRepository
    {
        public CenterRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<TechnicalExaminationCenter>> GetActiveCenters(int cityId)
        {
            return await _dbContext.TechnicalExaminationCenters
                .AsNoTracking()
                .Where(c => c.CityId == cityId)
                .ToListAsync();
        }
    }
}
