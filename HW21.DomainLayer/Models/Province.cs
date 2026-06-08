using HW21.DomainLayer.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.DomainLayer.Models
{
    public class Province : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();

        public override void Validation()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new Exception("Name is required !");
        }
    }
}
