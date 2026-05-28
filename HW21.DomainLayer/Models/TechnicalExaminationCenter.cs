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
    }
}
