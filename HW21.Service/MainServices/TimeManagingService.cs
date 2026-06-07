using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Service.DtoServices;
using HW21.Service.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.MainServices
{
    public class TimeManagingService : ITimeManagingService
    {
        private readonly ITimeManagingRepository _timeRepository;

        public TimeManagingService(ITimeManagingRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

       
    }
}
