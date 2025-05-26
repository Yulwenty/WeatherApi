using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Core.DTO.City;
using WeatherApi.Core.IServices;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCitiesByCountry(int id)
        {
            var cities = await _cityService.GetAllCitiesByCountryId(id);
            return Ok(cities);
        }
        //public async Task<ActionResult<CityDetailDto>> GetAllCitiesByCountry(int id)
        //{
        //    var cities = await _cityService.GetAllCitiesByCountryId(id);
        //    return Ok(cities);
        //}
    }
}
