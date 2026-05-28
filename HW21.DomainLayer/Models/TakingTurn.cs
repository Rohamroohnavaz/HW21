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
    public class TakingTurn : BaseEntity
    {
        public User User { get; set; }
        [Required]
        public int UserId { get; set; }
        public Car Car { get; set; }
        [Required]
        public int CarId { get; set; }
        public TechnicalExaminationCenter Center { get; set; }
        [Required]
        public int CenterId { get; set; }
        public string ResultText { get; set; }
        public City City { get; set; }
        public Province Province { get; set; }
        public TimeManaging Time { get; set; }
        [Required]
        public Status Status { get; set; } = Status.Active;
    }
}
