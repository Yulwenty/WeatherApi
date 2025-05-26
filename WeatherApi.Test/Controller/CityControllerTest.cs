using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Controllers;
using WeatherApi.Core.DTO.City;
using WeatherApi.Core.IServices;

namespace WeatherApi.Test.Controller
{
    [TestFixture]
    public class CityControllerTest
    {
        private CityController _controller;
        private Mock<ICityService> _cityServiceMock;

        [SetUp]
        public void Setup()
        {
            _cityServiceMock = new Mock<ICityService>();
            _controller = new CityController(_cityServiceMock.Object);
        }

        [Test]
        public async Task GetAllCitiesByCountry_ReturnsOk_WithCityList()
        {
            // Arrange
            int countryId = 1;
            var mockCities = new List<CityDetailDto>
            {
                new CityDetailDto { Id = 1, CountryId=1, Name = "London" },
                new CityDetailDto { Id = 2, CountryId=1, Name = "Manchester" }
            };

            _cityServiceMock
                .Setup(service => service.GetAllCitiesByCountryId(countryId))
                .ReturnsAsync(mockCities);

            // Act
            var result = await _controller.GetAllCitiesByCountry(countryId);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsInstanceOf<List<CityDetailDto>>(okResult.Value);

            var cities = okResult.Value as List<CityDetailDto>;
            Assert.AreEqual(2, cities.Count);
        }

        [Test]
        public async Task GetAllCitiesByCountry_ReturnsOk_WithEmptyList()
        {
            // Arrange
            int countryId = 999;
            _cityServiceMock
                .Setup(service => service.GetAllCitiesByCountryId(countryId))
                .ReturnsAsync(new List<CityDetailDto>());

            // Act
            var result = await _controller.GetAllCitiesByCountry(countryId);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var cities = okResult.Value as List<CityDetailDto>;
            Assert.IsNotNull(cities);
            Assert.AreEqual(0, cities.Count);
        }

    }
}
