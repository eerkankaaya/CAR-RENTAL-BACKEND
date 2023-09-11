using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;


        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
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
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbycarname")]
        public IActionResult Get(string car)
        {
            var result = _carService.Get(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbranddetails")]
        public IActionResult GetBrandDetails()
        {
            var result = _carService.GetBrandDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getcolordetails")]
        public IActionResult GetColorDetails()
        {
            var result = _carService.GetColorDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            Thread.Sleep(5000);
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getrentaldetails")]
        public IActionResult GetRentalDetails()
        {
            var result = _carService.GetRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getcustomerdetails")]
        public IActionResult GetCustomerDetails()
        {
            var result = _carService.GetCustomerDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }







    }
}
