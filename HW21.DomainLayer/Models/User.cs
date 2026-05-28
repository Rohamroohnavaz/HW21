using HW21.DomainLayer.Abstractions;
using HW21.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.DomainLayer.Models
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        [MaxLength(15)]
        public long PhoneNumber { get; set; }
        [Required]
        public Role Role { get; set; } = Role.NormalUser;
        public List<Car> Cars { get; set; }
    }
}
