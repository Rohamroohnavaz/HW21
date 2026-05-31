using HW21.DomainLayer.Models;
using HW21.Infrastructure.Data;
using HW21.Repository.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Repository.MainRepositories.Repos
{
    public class CityRepository : GenericRepository<City>
    {
        public CityRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
