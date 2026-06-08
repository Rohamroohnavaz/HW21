using HW21.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.DtoServices
{
    public class TurnDto
    {
        public int Id { get; set; }

        public int Capacity { get; set; }

        public int CenterId { get; set; }

        public Status Status { get; set; }
    }
}
