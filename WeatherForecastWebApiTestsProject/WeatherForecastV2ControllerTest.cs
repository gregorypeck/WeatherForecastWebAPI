using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherForecastWebAPI.Controllers;
using WeatherForecastWebAPI.Queries.V2;
using WeatherForecastWebAPI.Service.V2;

namespace WeatherForecastWebApiTestsProject
{
    [TestFixture]
    public class WeatherForecastV2ControllerTest
    {
        private WeatherForecastControllerV2 _controller;
        private Mock<IWeatherForecastServiceV2> _service;

        [SetUp]
        public void PrepareTestForControllerV2()
        {
            _service = new Mock<IWeatherForecastServiceV2>();
            _controller = new WeatherForecastControllerV2(_service.Object);
        }

        [Test]
        public async Task UpdateWeatherForecastV2()
        {
            var weather = new UpdateWeatherForecastQueryV2
            {
                Latitude = 100,
                Longitude = 100,
                Date = new DateTime(2024, 4, 1, 02, 00, 0),
                TemperatureC = 100
            };

            IActionResult actionResult = await _controller.PutUpdateWeatherForecas(weather);
            var okObjectResult = actionResult as OkResult;
            Assert.IsNotNull(okObjectResult);
            Assert.IsInstanceOf<OkResult>(actionResult);

        }

        [Test]
        public async Task AddWeatherForecastV2()
        {
            var weather = new AddWeatherForecastQueryV2
            {
                 Latitude = 100,
                 Longitude = 100,
                 Date = new DateTime(2024, 4, 1, 02, 00, 0),
                 TemperatureC = 100
             };

            IActionResult actionResult = await _controller.PostCreateWeatherForecast(weather);
            var okObjectResult = actionResult as OkResult;
            Assert.IsNotNull(okObjectResult);
            Assert.IsInstanceOf<OkResult>(actionResult);

        }

        [Test]
        public async Task DeleteWeatherForecastV2()
        {
            var weather = new DeleteWeatherForecastQueryV2
            {
                Latitude = 100,
                Longitude = 100,
                Date = new DateTime(2024, 4, 1, 02, 00, 0)
            };

            IActionResult actionResult = await _controller.DeleteWeatherForecast(weather);
            var okObjectResult = actionResult as OkResult;
            Assert.IsNotNull(okObjectResult);
            Assert.IsInstanceOf<OkResult>(actionResult);

        }

    }
}