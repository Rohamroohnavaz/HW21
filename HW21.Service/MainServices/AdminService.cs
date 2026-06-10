using HW21.Infrastructure.Data;
using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Service.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.MainServices
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepository;

        public AdminService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
