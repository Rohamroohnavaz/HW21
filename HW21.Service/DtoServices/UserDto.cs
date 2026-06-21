using HW21.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.DtoServices
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public long PhoneNumber { get; set; }
        public Role Role { get; set; }
    }
}
