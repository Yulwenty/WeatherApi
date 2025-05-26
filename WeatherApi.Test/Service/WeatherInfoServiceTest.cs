using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WeatherApi.Core.Error;
using WeatherApi.Core.IRepositories;
using WeatherApi.Core.IServices;
using WeatherApi.Core.Models;
using WeatherApi.Service;

namespace WeatherApi.Test.Service
{
    [TestFixture]
    public class WeatherInfoServiceTest
    {
        private Mock<IWeatherInfoRepository> _weatherInfoRepo;
        private Mock<IMapper> _mapper;
        private WeatherInfoService _weatherInfoService;
        [SetUp]
        public void Setup()
        {
            _weatherInfoRepo = new Mock<IWeatherInfoRepository>();
            _mapper = new Mock<IMapper>();
            _weatherInfoService = new WeatherInfoService(_weatherInfoRepo.Object, _mapper.Object);
        }

        [TestCase(32, 0)]
        [TestCase(75, 23.89)]
        public void ConvertTemperatureFromFarenheit_ToCelcius(double temperatureF, double expected)
        {
            Assert.AreEqual(_weatherInfoService.ConvertTemperatureFromFarenheit_ToCelcius(temperatureF), expected);

        }

        [Test]
        public async Task GetWeatherInfo_ReturnsNotFound()
        {
            // Arrange
            int cityId = 999;
            WeatherInfo mockWeatherInfo = null;

            _weatherInfoRepo
                .Setup(repo => repo.GetWeatherInfo(cityId))
                .ReturnsAsync(mockWeatherInfo);
       
            // Assert
            var ex = Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                // Act
                await _weatherInfoService.GetWeatherInfo(cityId);
            });
        }
    }
}
