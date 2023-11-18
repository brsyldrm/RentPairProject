using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _userService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpDelete("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
