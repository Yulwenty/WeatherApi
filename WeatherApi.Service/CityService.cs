using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Core.DTO.City;
using WeatherApi.Core.IRepositories;
using WeatherApi.Core.IServices;

namespace WeatherApi.Service
{
    public class CityService : ICityService
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<List<CityDetailDto>> GetAllCitiesByCountryId(int countryId)
        {
            var cities = await _cityRepository.GetAllCitiesByCountry(countryId);
            return _mapper.Map<List<CityDetailDto>>(cities.ToList());
        }
    }
}
