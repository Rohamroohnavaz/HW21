using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.Exceptions
{
    public class PermissionDeniedException : BaseBussinessException
    {
        public PermissionDeniedException(Exception? innerException = null) 
            : base("Permission Denied!You can't access thid resource!", "403", innerException) { }
    }
}
