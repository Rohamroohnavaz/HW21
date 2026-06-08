using HW21.Service.InterfaceServices;
using HW21.Service.MainServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurnController : Controller
    {
        private readonly TakingTurnService _turnService;

        public TurnController(TakingTurnService turnService)
        {
            _turnService = turnService;
        }

        [HttpGet("GetAllTurns")]
        public async Task<IActionResult> GetAllTurns()
        {
            var turns = await _turnService.GetAllTurnsDto();

            return Ok(turns);
        }
    }
}
