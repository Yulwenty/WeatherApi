using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Core.DTO.WeatherInfo;

namespace WeatherApi.Core.IServices
{
    public interface IWeatherInfoService
    {
        Task<WeatherInfoDetailDto> GetWeatherInfo(int cityId);
        double ConvertTemperatureFromFarenheit_ToCelcius(double temperatureF);
    }
}
