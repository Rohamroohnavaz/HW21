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
    public class CityRepository : GenericRepository<City> ,ICityRepository
    {
        public CityRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<City>> GetCityByProvinceId(int provinceId)
        {
            return await _dbContext.Cities
                .AsNoTracking()
                .Where(c => c.ProvinceId == provinceId)
                .ToListAsync();
        }
    }
}
