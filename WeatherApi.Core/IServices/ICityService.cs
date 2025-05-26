using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Core.DTO.City;

namespace WeatherApi.Core.IServices
{
    public interface ICityService
    {
        Task<List<CityDetailDto>> GetAllCitiesByCountryId(int countryId);
    }
}
