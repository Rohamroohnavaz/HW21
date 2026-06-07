using HW21.Service.DtoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.InterfaceServices
{
    public interface IGetEmptyTimeSpacesService
    {
        Task<List<TimeManagingDto>> GetEmptySpaceAsync(int centerId ,DateTime date);
    }
}
