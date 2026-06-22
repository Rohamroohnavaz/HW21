using HW21.DomainLayer.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.Exceptions
{
    public class BaseBussinessException : BaseException
    {
        public BaseBussinessException(string message ,string code ,Exception? innerException = null)
            : base(message ,$"BussinessException_{code}" ,innerException) { }
    }
}
