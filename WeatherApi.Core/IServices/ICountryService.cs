using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Core.DTO.Country;

namespace WeatherApi.Core.IServices
{
    public interface ICountryService
    {
        Task<List<CountryDetailDto>> GetAllCountries();
    }
}
