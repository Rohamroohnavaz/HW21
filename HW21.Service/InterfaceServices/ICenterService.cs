using HW21.DomainLayer.Models;
using HW21.Service.DtoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.InterfaceServices
{
    public interface ICenterService
    {
        Task<List<CenterDto>> GetActiveCenterByCityIdAsync(int cityId);

        Task<GetCenterDto?> GetById(int id);
    }
}
