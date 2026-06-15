using HW21.DomainLayer.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.DomainLayer.Models
{
    public class TimeManaging : BaseEntity
    {
        public TimeManaging()
        {
            
        }

        public TimeManaging(TimeSpan startTime ,TimeSpan endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            Validation();
        }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TechnicalExaminationCenter Center { get; set; }
        public int CenterId { get; set; }
        public ICollection<TakingTurn> Turns { get; set; } = new List<TakingTurn>();

        public override void Validation()
        {
            throw new NotImplementedException();
        }
    }
    
}
