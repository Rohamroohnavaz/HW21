using HW21.Repository.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.MainServices.Caching
{
    public interface ICacheService
    {
        Task<T?> Get<T>(string cacheKey);

        Task Set<T>(string cacheKey, T value ,TimeSpan expiry);
    }
}
