using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.Exceptions
{
    public class ItemNotFoundException : BaseBussinessException
    {
        public ItemNotFoundException(string itemName ,Type type ,Exception? innerException = null)
            : base($"{itemName} Not Found !" ,$"{type.Name}__404" ,innerException) { }
    }
}
