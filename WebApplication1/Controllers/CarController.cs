using HW21.DomainLayer.Models;
using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Service.InterfaceServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarService _carService;

        public CarController(ICarRepository carRepository ,ICarService carService)
        {
            _carRepository = carRepository;
            _carService = carService;
        }

        [HttpGet("{carId:int}")]
        public async Task<ActionResult<Car>> GetCarById([FromRoute]int carId)
        {
            var car = await _carService.GetById(carId);

            if(car is null)
                return NotFound();

            return Ok(car);
        }
    }
}
