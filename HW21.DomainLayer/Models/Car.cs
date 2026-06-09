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
    public class Car : BaseEntity
    {
        public Car()
        {
            
        }

        public Car(string chassisNumber ,int userId)
        {
            ChassisNumber = chassisNumber;
            UserId = userId;
            Validation();
        }

        [Required]
        [MaxLength(20)]
        public string ChassisNumber { get; set; }
        [Required]
        public string CarName { get; set; }
        public User Owner { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public int UserId { get; set; }
        public List<TakingTurn> Turns { get; set; }

        public void UpdateCarInfo(string chassisNumber ,Status status)
        {
            ChassisNumber = chassisNumber;
            Status = status;
            Validation();
        }

        public override void Validation()
        {
            if (string.IsNullOrWhiteSpace(ChassisNumber))
                throw new Exception("ChassisNumber is required !");
        }
    }
}
