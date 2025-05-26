using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Core.Models;

namespace WeatherApi.Core.IRepositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountries();
    }
}
