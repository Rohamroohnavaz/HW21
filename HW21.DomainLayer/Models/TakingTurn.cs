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
        public TakingTurn()
        {
            
        }

        public TakingTurn(int capacity ,string resultText ,string provinceName ,string cityName)
        {
            Capacity = capacity;
            ResultText = resultText;
            ProvinceName = provinceName;
            CityName = cityName;
            Validation();
        }
        [Required]
        public int Capacity { get; set; }
        public Car Car { get; set; }
        [Required]
        public int CarId { get; set; }
        public TechnicalExaminationCenter Center { get; set; }
        [Required]
        public int CenterId { get; set; }
        public string ResultText { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public TimeManaging Time { get; set; }
        public int TimeId { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public ReserveStatus ReserveStatus { get; set; }

        public void UpdateTurnInfo(int capacity ,string resultText)
        {
            Capacity = capacity;
            ResultText = resultText;
            Validation();
        }

        public override void Validation()
        {
            if (Capacity < 0)
                throw new Exception("Capacity can not be negative !!");
            if (string.IsNullOrEmpty(ResultText))
                throw new Exception("!Null Value!");
        }
    }
}
