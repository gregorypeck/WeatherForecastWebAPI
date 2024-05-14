using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherForecastWebAPI.Controllers;
using WeatherForecastWebAPI.Queries.V1;
using WeatherForecastWebAPI.Service.V1;

namespace WeatherForecastWebApiTestsProject
{
    [TestFixture]
    public class WeatherForecastV1ControllerTest
    {
        private WeatherForecastControllerV1 _controller;
        private Mock<IWeatherForecastServiceV1> _service;

        [SetUp]
        public void PrepareTestForControllerV1()
        {
            _service = new Mock<IWeatherForecastServiceV1>();
            _controller = new WeatherForecastControllerV1(_service.Object);
        }

        [Test]
        public async Task AddWeatherForecastV1()
        {

            var weather = new AddWeatherForecastQueryV1
            {
                 Latitude = 100,
                 Longitude = 100,
                 Date = new DateTime(2024, 4, 1, 02, 00, 0),
                 TemperatureC = 1000
             };

            IActionResult actionResult =  await _controller.PostCreateWeatherForecast(weather);

            Assert.IsInstanceOf<OkResult>(actionResult);

            var okObjectResult = actionResult as OkResult;
            Assert.IsNotNull(okObjectResult);
            Assert.IsNotNull(actionResult);
            
        }
    }
}