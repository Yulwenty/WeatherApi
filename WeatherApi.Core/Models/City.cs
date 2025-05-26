using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApi.Core.Models
{
    public class City
    {
        public Int64 Id { get; set; }
        public Int64 CountryId { get; set; }
        public string Name { get; set; }
    }
}
