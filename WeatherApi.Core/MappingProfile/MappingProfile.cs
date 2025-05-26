using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApi.Core.DTO.City;
using WeatherApi.Core.DTO.Country;
using WeatherApi.Core.DTO.WeatherInfo;
using WeatherApi.Core.Models;

namespace WeatherApi.Core.MappingProfile
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Country
            CreateMap<Country, CountryDetailDto>();

            //City
            CreateMap<City, CityDetailDto>();

            //Weather
            CreateMap<WeatherInfo, WeatherInfoDetailDto>();
        }

    }
}
