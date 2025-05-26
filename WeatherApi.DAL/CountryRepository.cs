using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Core.IRepositories;
using WeatherApi.Core.Models;

namespace WeatherApi.DAL
{
    public class CountryRepository : ICountryRepository
    {
        private List<Country> _countryCollection;

        public CountryRepository()
        {
            _countryCollection = new List<Country>()
            {
                new Country() { Id =1, Name="Australia" },
                new Country() { Id =2, Name="Indonesia" },
                new Country() { Id =3, Name="Thailand" }            
            };
        }
        public Task<IEnumerable<Country>> GetAllCountries()
        {
            return Task.FromResult(_countryCollection.AsEnumerable());
        }
    }
}
