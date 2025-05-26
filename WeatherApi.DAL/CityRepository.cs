using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Core.IRepositories;
using WeatherApi.Core.Models;

namespace WeatherApi.DAL
{
    public class CityRepository : ICityRepository
    {
        private List<City> _cityCollection;

        public CityRepository()
        {
            _cityCollection = new List<City>()
            {
                new City() { Id = 1, CountryId = 1, Name = "Canberra" },
                new City() { Id = 2, CountryId = 1, Name = "Sydney" },
                new City() { Id = 3, CountryId = 1, Name = "Melbourne" },
                new City() { Id = 4, CountryId = 2, Name = "Jakarta" },
                new City() { Id = 5, CountryId = 2, Name = "Bali" },
                new City() { Id = 6, CountryId = 3, Name = "Bangkok" }
            };
        }
        public  Task<IEnumerable<City>> GetAllCitiesByCountry(Int64 countryId)
        {
            var cities = _cityCollection.Where(x => x.CountryId == countryId);
            return Task.FromResult(cities);
        }
    }
}
