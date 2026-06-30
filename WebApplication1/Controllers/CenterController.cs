using HW21.DomainLayer.Models;
using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Service.InterfaceServices;
using HW21.Service.MainServices.Redis;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CenterController : Controller
    {
        private readonly ICenterRepository _centerRepository;
        private readonly ICenterService _centerService;
        //private readonly IRedisService _redisService;
        private readonly IGetEmptyTimeSpacesService _getEmptyTimeSpacesService;

        public CenterController(ICenterRepository centerRepository
            , ICenterService centerService
            , IGetEmptyTimeSpacesService getEmptyTimeSpacesService)
        {
            _centerRepository = centerRepository;
            _centerService = centerService;
            _getEmptyTimeSpacesService = getEmptyTimeSpacesService;
        }

        [HttpGet("{centerId:int}")]
        public async Task<IActionResult> GetCenterById([FromRoute] int centerId)
        {
            var center = await _centerService.GetById(centerId);

            if (center == null)
                return NotFound();

            return Ok(center);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmptyTimes([FromRoute] int centerId, [FromQuery] DateTime date)
        {
            var times = await _getEmptyTimeSpacesService.GetEmptySpaceAsync(centerId, date);

            return Ok(times);
        }
    }
}
