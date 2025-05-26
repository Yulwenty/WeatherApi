using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Core.DTO.WeatherInfo;
using WeatherApi.Core.Error;
using WeatherApi.Core.IServices;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
        private readonly IWeatherInfoService _weatherInfoService;
        public WeatherController(IWeatherInfoService weatherInfoService)
        {
            _weatherInfoService = weatherInfoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeatherInfoByCity(int id)
        {
            
            try
            {
                var weatherInfo = await _weatherInfoService.GetWeatherInfo(id);
                return Ok(weatherInfo);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
