using HW21.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.DtoServices
{
    public class GetCenterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int TurnCount { get; set; }
        public string Address { get; set; }
        public Status Status { get; set; } = Status.None;
    }
}
