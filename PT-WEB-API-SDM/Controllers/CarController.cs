using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PT_WEB_API_SDM.Models;
using PT_WEB_API_SDM.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PT_WEB_API_SDM.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly CarService _carService;
        public CarController(CarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars()
        {
            var cars = await _carService.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            var car = await _carService.GetcarById(id);
            return Ok(car);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(Car car)
        {
            try
            {
                await _carService.CreateCar(car);
                return new OkObjectResult(car);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, Car car)
        {
            try
            {
                await _carService.UpdateCar(id, car);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                await _carService.DeleteCar(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}

