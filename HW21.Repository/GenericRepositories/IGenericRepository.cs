using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Repository.GenericRepositories
{
    public interface IGenericRepository<T>
    {
        Task AddAsync(T entity);

        Task<List<T>> GetAllAsync();

        Task<T>? GetByIdAsync(int id);

        Task UpdateAsync(T entity);

        Task HardDeleteAsync(int id);

        Task SoftDeleteAsync(int id);
    }
}
