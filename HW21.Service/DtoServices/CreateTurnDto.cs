using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.DtoServices
{
    public class CreateTurnDto
    {
        public int CenterId { get; set; }
        public int CarId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
    }
}
