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
        public User()
        {
            
        }

        public User(string username, string password, long phoneNumber)
        {
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
        }

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

        public override void Validation()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                throw new Exception("!Null Value!");

            if (PhoneNumber < 10)
                throw new Exception("Invalid PhoneNumber!!");
        }
    }
}
