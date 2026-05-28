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
        [Required]
        [MaxLength(20)]
        public string ChassisNumber { get; set; }
        public User Owner { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public int UserId { get; set; }
        public List<TakingTurn> Turns { get; set; }
    }
}
