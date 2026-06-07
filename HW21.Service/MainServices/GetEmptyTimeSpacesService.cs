using HW21.DomainLayer.Enums;
using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Service.DtoServices;
using HW21.Service.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Service.MainServices
{
    public class GetEmptyTimeSpacesService : IGetEmptyTimeSpacesService
    {
        private readonly ITakingTurnRepository _turnRepository;
        private readonly ICenterRepository _centerRepository;

        public GetEmptyTimeSpacesService(ITakingTurnRepository turnRepository, ICenterRepository centerRepository)
        {
            _turnRepository = turnRepository;
            _centerRepository = centerRepository;
        }
        public async Task<List<TimeManagingDto>> GetEmptySpaceAsync(int centerId, DateTime date)
        {
            var center = _centerRepository.GetByIdAsync(centerId);

            if (center is null || (int)center.Status != (int)Status.Active)
                return new List<TimeManagingDto>();

            var turns = await _turnRepository.GetTurnsByCenterIdAndDate(centerId, date);

            var times = new List<TimeManagingDto>();
            return times.Select(x => new TimeManagingDto
            {
                CenterId = x.CenterId,
                Date = date,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Status = Status.Active
            }).ToList();

        }
    }
}
