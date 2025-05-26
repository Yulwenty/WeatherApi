using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApi.Core.DTO.City
{
    public class CityDetailDto
    {
        public Int64 Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
