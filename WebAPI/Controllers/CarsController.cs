using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _carService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPost("add")]
        public IActionResult Add(Car Car)
        {
            var result = _carService.Add(Car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpDelete("delete")]
        public IActionResult Delete(Car Car)
        {
            var result = _carService.Add(Car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update(Car Car)
        {
            var result = _carService.Update(Car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
