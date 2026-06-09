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
    public class TechnicalExaminationCenter : BaseEntity
    {
        public TechnicalExaminationCenter()
        {
            
        }

        public TechnicalExaminationCenter(string name ,string address ,int turnCount ,DateTime visitTime)
        {
            Name = name;
            Address = address;
            TurnCount = turnCount;
            VisitTime = visitTime;
            Validation();
        }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        public int TurnCount { get; set; }
        public DateTime VisitTime { get; set; }
        public City City { get; set; }
        [Required]
        public int CityId { get; set; }
        public Province Province { get; set; }
        [Required]
        public int ProvinceId { get; set; }
        [Required]
        public Status Status { get; set; } = Status.Active;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public void UpdateCenterInfo(string name ,string address ,int turnCount)
        {
            Name = name;
            Address = address;
            TurnCount = turnCount;
            Validation();
        }

        public override void Validation()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new Exception("Name is required !!");
            if(string.IsNullOrWhiteSpace(Address))
                throw new Exception("Address is required !!");
        }
    }
}
