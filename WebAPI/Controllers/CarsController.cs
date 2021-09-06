using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // attribute
    public class CarsController : ControllerBase
    {
        //IoC Container -- Inversion of Control
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(1000);
            
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public  IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcardetailsbydto")]
        public IActionResult GetDetailsByDto()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbybrandid")]
        public IActionResult GetByBrand(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycolorid")]
        public IActionResult GetByColor(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpGet("getcardetailsbycolorid")]
        public IActionResult GetCarDetailsByColorId(int colorId)
        {
            var result = _carService.GetCarDetailsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcardetailsbybrandid")]
        public IActionResult GetCarDetailsByBrandId(int brandId)
        {
            var result = _carService.GetCarDetailsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcardetailsbycarid")]
        public IActionResult GetCarDetailsByCarId(int carId)
        {
            var result = _carService.GetCarDetailsByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
