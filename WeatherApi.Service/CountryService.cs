using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Core.DTO.Country;
using WeatherApi.Core.IRepositories;
using WeatherApi.Core.IServices;
using WeatherApi.Core.Models;

namespace WeatherApi.Service
{
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<List<CountryDetailDto>> GetAllCountries()
        {
            var countries = await _countryRepository.GetAllCountries();
           
            return _mapper.Map<List<CountryDetailDto>>(countries.ToList());
          
        }
    }
}
