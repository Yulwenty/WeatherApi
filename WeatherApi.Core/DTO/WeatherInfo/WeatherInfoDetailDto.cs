using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApi.Core.DTO.WeatherInfo
{
    public class WeatherInfoDetailDto
    {
     
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public double WindSpeed { get; set; }
        public double Visibility { get; set; }
        public string SkyCondition { get; set; }
        public double TemperatureF { get; set; }
        public double TemperatureC { get; set; }
        public double DewPoint { get; set; }
        public int HumidityPercent { get; set; }
        public int Pressure { get; set; }
    }
}
