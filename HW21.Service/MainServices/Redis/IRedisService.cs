using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.MainServices.Redis
{
    public interface IRedisService
    {
        Task<bool> ExistAsync(string key);
    }
}
