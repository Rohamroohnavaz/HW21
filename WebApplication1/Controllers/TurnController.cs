using HW21.DomainLayer.Models;
using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Repository.MainRepositories.Repos;
using HW21.Service.DtoServices;
using HW21.Service.InterfaceServices;
using HW21.Service.MainServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurnController : Controller
    {
        private readonly ITakingTurnService _turnService;
        private readonly ITakingTurnRepository _turnRepository;
        private readonly IGetEmptyTimeSpacesService _getEmptyTimeSpacesService;

        public TurnController(TakingTurnService turnService
            ,ITakingTurnRepository turnRepository 
            ,IGetEmptyTimeSpacesService getEmptyTimeSpacesService)
        {
            _turnService = turnService;
            _turnRepository = turnRepository;
            _getEmptyTimeSpacesService = getEmptyTimeSpacesService;
        }

        [HttpGet("GetAllTurns")]
        public async Task<IActionResult> GetAllTurns()
        {
            var turns = await _turnService.GetAllTurnsDto();

            if (turns == null)
                NotFound("Turns Not Found!");

            return Ok(turns);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var turn = await _turnService.GetById(id);

            if (turn is null)
                return NotFound();

            return Ok(turn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTurn([FromBody] CreateTurnDto dto, [FromRoute] int userId,[FromRoute] int timeManageId)
        {
            await _turnService.CreateTurnForUserById(dto, userId, timeManageId);
            var turn = new TakingTurn(dto.Capacity, dto.ResultText, dto.ProvinceName, dto.CityName);

            if (turn is null)
                return NotFound("Turn Not Found !!");

            await _turnRepository.AddAsync(turn);
            return Created();
        }

        [HttpGet("{centerId}/empty-spaces")]
        public async Task<IActionResult> GetEmptySpaces([FromRoute] int centerId ,[FromQuery]DateTime date)
        {
            var time = await _getEmptyTimeSpacesService.GetEmptySpaceAsync(centerId, date);

            return Ok(time);
        }
    }
}
