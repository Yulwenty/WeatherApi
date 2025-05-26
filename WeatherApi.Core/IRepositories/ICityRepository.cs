using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Core.Models;

namespace WeatherApi.Core.IRepositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCitiesByCountry(Int64 countryId);
    }
}
