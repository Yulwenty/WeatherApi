using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Core.DTO.WeatherInfo;
using WeatherApi.Core.Error;
using WeatherApi.Core.IRepositories;
using WeatherApi.Core.IServices;

namespace WeatherApi.Service
{
    public class WeatherInfoService : IWeatherInfoService
    {
        private readonly IMapper _mapper;
        private readonly IWeatherInfoRepository _weatherRepository;
        public WeatherInfoService(IWeatherInfoRepository weatherRepository, IMapper mapper)
        {
            _weatherRepository = weatherRepository;
            _mapper = mapper;
        }
        public async Task<WeatherInfoDetailDto> GetWeatherInfo(int cityId)
        {
            var weatherInfo = await _weatherRepository.GetWeatherInfo(cityId);
            if(weatherInfo == null)
            {
                throw new NotFoundException( "Weather Info doesn't exist for this City");
            }
            weatherInfo.TemperatureC = ConvertTemperatureFromFarenheit_ToCelcius(weatherInfo.TemperatureF);

            return _mapper.Map<WeatherInfoDetailDto>(weatherInfo);
        }

        public double ConvertTemperatureFromFarenheit_ToCelcius(double temperatureF)
        {
           return Math.Round((temperatureF - 32) * 5 / 9, 2);
        }
    }
}
