using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApi.Core.Models
{
    public class WeatherInfo
    {
        public Int64 CityId { get; private set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public double WindSpeed { get; set; }
     //   public string windUnit => "m/s";
        public double Visibility { get; set; }
        public string SkyCondition { get; set; }
        public double TemperatureF { get; set; }
        public double TemperatureC { get; set; }
        public double DewPoint => CalculateDewPoint();
        public int HumidityPercent { get; set; }
        public int Pressure { get; set; }

     
        public WeatherInfo(Int64 id, string location, DateTime time, double windSpeed, double visibility, string skyCondition,
              double temperatureFarenheit, int humidityPercent, int pressure)
        {
            if (humidityPercent < 0 || humidityPercent > 100)
                throw new ArgumentOutOfRangeException(nameof(humidityPercent), "Humidity must be between 0 and 100");

            CityId = id;
            Location = location ?? throw new ArgumentNullException(nameof(location));
            Time = time;
            WindSpeed = windSpeed;
            Visibility = visibility;
            SkyCondition = skyCondition;
            TemperatureF = temperatureFarenheit;
            HumidityPercent = humidityPercent;
            Pressure = pressure;
        }

        private double CalculateDewPoint()
        {
            var tempC = (TemperatureF - 32) * 5 / 9;
            const double a = 17.27;
            const double b = 237.7;

            double alpha = ((a * tempC) / (b + tempC)) +
                           Math.Log(HumidityPercent / 100.0);

            double dewPoint = (b * alpha) / (a - alpha);
            return Math.Round(dewPoint, 2);
        }
        
    }

}
