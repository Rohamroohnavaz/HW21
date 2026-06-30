using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HW21.Service.MainServices.Caching
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> Get<T>(string cacheKey)
        {
            var getData = await _cache.GetAsync(cacheKey);
            if(getData == null)
                return default(T?);

            return JsonSerializer.Deserialize<T>(getData);
        }

        public async Task Set<T>(string cacheKey, T value, TimeSpan expiry)
        {
            var json = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(cacheKey, json, new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = expiry,
            });
        }
    }
}
