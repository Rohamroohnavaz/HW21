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
        [Required]
        public int Capacity { get; set; }
        public Car Car { get; set; }
        [Required]
        public int CarId { get; set; }
        public TechnicalExaminationCenter Center { get; set; }
        [Required]
        public int CenterId { get; set; }
        public string ResultText { get; set; }
        public TimeManaging Time { get; set; }
        public int TimeId { get; set; }
        [Required]
        public Status Status { get; set; } = Status.Active;
        [Required]
        public ReserveStatus ReserveStatus { get; set; } = ReserveStatus.None;

        public override void Validation()
        {
            if (Capacity < 0)
                throw new Exception("Capacity can not be negative !!");
            if (string.IsNullOrEmpty(ResultText))
                throw new Exception("!Null Value!");
        }
    }
}
