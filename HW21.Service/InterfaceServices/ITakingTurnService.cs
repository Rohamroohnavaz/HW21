using HW21.Service.DtoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.InterfaceServices
{
    public interface ITakingTurnService
    {
        Task CreateTurnForUser(CreateTurnDto dto, int userId ,int timeManagingId);
    }
}
