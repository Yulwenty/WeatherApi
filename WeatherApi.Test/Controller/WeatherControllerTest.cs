using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WeatherApi.Controllers;
using WeatherApi.Core.DTO.WeatherInfo;
using WeatherApi.Core.Error;
using WeatherApi.Core.IServices;

namespace WeatherApi.Test.Controller
{
    [TestFixture]
    public class WeatherControllerTest
    {
        private WeatherController _controller;
        private Mock<IWeatherInfoService> _weatherInfoServiceMock;

        [SetUp]
        public void Setup()
        {
            _weatherInfoServiceMock = new Mock<IWeatherInfoService>();
            _controller = new WeatherController(_weatherInfoServiceMock.Object);
        }

        [Test]
        public async Task GetWeatherInfoByCity_ReturnsNotFound_WhenCityDoesNotExist()
        {
            // Arrange
            int cityId = 999;
            var expectedMessage = "Weather Info doesn't exist for this City";

            _weatherInfoServiceMock
                .Setup(s => s.GetWeatherInfo(cityId))
                .ThrowsAsync(new NotFoundException(expectedMessage));

            var controller = new WeatherController(_weatherInfoServiceMock.Object);

            // Act
            var result = await controller.GetWeatherInfoByCity(cityId);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
            var notFoundResult = result as NotFoundObjectResult;
            Assert.AreEqual(404, notFoundResult?.StatusCode);
            Assert.AreEqual(expectedMessage, notFoundResult?.Value);
        }
    }
}
