using HW21.DomainLayer.Models;
using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Service.InterfaceServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CenterController : Controller
    {
        private readonly ICenterRepository _centerRepository;
        private readonly ICenterService _centerService;

        public CenterController(ICenterRepository centerRepository ,ICenterService centerService)
        {
            _centerRepository = centerRepository;
            _centerService = centerService;
        }

        [HttpGet("{centerId:int}")]
        public async Task<IActionResult> GetCenterById([FromRoute]int centerId)
        {
            var center = await _centerService.GetById(centerId);

            if(center == null)
                return NotFound();

            return Ok(center);
        }
    }
}
