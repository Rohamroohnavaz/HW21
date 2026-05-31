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
        private readonly AppDbContext _context;

        public AdminService(IUserRepository userRepository ,AppDbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }
    }
}
