using HW21.DomainLayer.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.DomainLayer.Models
{
    public class City : BaseEntity
    {
        public City()
        {
            
        }

        public City(string name ,int provinceId)
        {
            Name = name;
            ProvinceId = provinceId;
            Validation();
        }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public Province Province { get; set; }
        [Required]
        public int ProvinceId { get; set; }
        [Required]
        public ICollection<TechnicalExaminationCenter> Centers { get; set; }
            = new List<TechnicalExaminationCenter>();

        public override void Validation()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new Exception("Name is required !");
        }
    }
}
