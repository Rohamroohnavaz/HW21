using HW21.DomainLayer.Models;
using HW21.Repository.MainRepositories.RepoInterfaces;
using HW21.Repository.MainRepositories.Repos;
using HW21.Repository.RepoDto;
using HW21.Service.DtoServices;
using HW21.Service.Exceptions;
using HW21.Service.InterfaceServices;
using HW21.Service.MainServices;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.WebDTO;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICarRepository _carRepository;
        private readonly IUserRepository _userRepository;

        public UserController(IUserService userService, ICarRepository carRepository
            , IUserRepository userRepository)
        {
            _userService = userService;
            _carRepository = carRepository;
            _userRepository = userRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUserById([FromRoute] int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user is null)
                return NotFound("User Not Found !!");

            return Ok(user);
        }

        [HttpPost("/AddUser")]
        public async Task<IActionResult> AddUser([FromBody]AddUserDto dto)
        {
            try
            {
                var user = new User(dto.Id, dto.Username, dto.Password, dto.Phonenumber);
                await _userRepository.AddAsync(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }

            return Created();
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser([FromBody] UserDto dto, [FromRoute]int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            try
            {
                await _userService.UpdateUserInfo(dto, id);
            }
            catch(UserNotFoundException ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }

            return Ok(user);
        }

        [HttpPost("/Register")]
        public async Task<ActionResult<int>> RegisterUser([FromBody]RegisterUserDto dto)
        {
            var userId = await _userRepository.RegisterUser(dto.UserName, dto.Password, dto.PhoneNumber);
            return Ok(userId);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddCar([FromQuery]string chassisNumber)
        //{
        //    var car = await _userService.AddCarsWithChassisNumberAsync(chassisNumber);

        //    if(car is null)
        //        return NotFound("Car Not Found !!");

        //    await _carRepository.AddAsync(car);
        //    return Created();
        //}
    }
}
