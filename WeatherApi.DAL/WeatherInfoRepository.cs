using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Core.IRepositories;
using WeatherApi.Core.Models;

namespace WeatherApi.DAL
{
    public class WeatherInfoRepository: IWeatherInfoRepository
    {
        private List<WeatherInfo> _weatherCollection;

        public WeatherInfoRepository()
        {
            _weatherCollection = new List<WeatherInfo>()
            {
               new WeatherInfo(4,"Jakarta",DateTime.UtcNow,5.2, 6.2,"Partly Cloudy",88.0,74,1012),
               new WeatherInfo(5,"Bali",DateTime.UtcNow,6.0,7.0,"Sunny",90.1,69,1011),
               new WeatherInfo(1,"Canberra",DateTime.UtcNow,3.1,9.3,"Clear",62.3,55,1020),
               new WeatherInfo(2,"Sydney",DateTime.UtcNow,8.4,7.8,"Overcast",64.5,61,1018),
               new WeatherInfo(3,"Melbourne",DateTime.UtcNow,9.2,5.0,"Rain Showers",64.5,81,1009),
               new WeatherInfo(6,"Bangkok",DateTime.UtcNow,10.5,4.5,"Thunderstorms",64.5,78,1008)      
            };
        }

        public Task<WeatherInfo> GetWeatherInfo(Int64 cityId)
        {
           var info = _weatherCollection.FirstOrDefault(f => f.CityId == cityId);
            return Task.FromResult(info);
        }
    }
}
