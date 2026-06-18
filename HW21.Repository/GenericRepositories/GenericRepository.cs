using HW21.DomainLayer.Abstractions;
using HW21.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Repository.GenericRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _dbContext;

        protected GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            //var query = _dbContext.Set<T>().AsNoTracking();
            //return await query.ToListAsync();
            var databaseName = _dbContext.Database.GetDbConnection().Database;
            var dataSource = _dbContext.Database.GetDbConnection().DataSource;

            var entityType = _dbContext.Model.FindEntityType(typeof(T));
            var tableName = entityType?.GetTableName();
            var schema = entityType?.GetSchema();
            var sql = _dbContext.Set<T>().AsNoTracking().ToQueryString();

            var result = await _dbContext.Set<T>().AsNoTracking().ToListAsync();

            var count = result.Count;

            return result;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var query = await _dbContext.Set<T>()
                .AsQueryable()
                .FirstOrDefaultAsync(q => q.Id == id);

            return query;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task HardDeleteAsync(int id)
        {
            var findEntity = await GetByIdAsync(id);

            if (findEntity is null) return;

            _dbContext.Set<T>().Remove(findEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var findEntity = await GetByIdAsync(id);

            if (findEntity is null) return;

            findEntity.SetAsDeleted();
            await _dbContext.SaveChangesAsync();
        }
    }
}
