using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using WeatherForecastWebAPI.DBContext;
using WeatherForecastWebAPI.MapperHelper;
using WeatherForecastWebAPI.Queries.V1;
using WeatherForecastWebAPI.Service.V1;

namespace WeatherForecastWebApiTestsProject
{
    [TestFixture]
    public class WeatherForecastV1ServiceTest
    {
        private WeatherForecastServiceV1 _service;
        private IMapper _mapper;
        private WeatherForecastInMemoryContext _context;
        private MapperConfiguration _config;

        [SetUp]
        public void PrepareTestForServiceV1()
        {
            var options = new DbContextOptionsBuilder<WeatherForecastInMemoryContext>()
                        .UseInMemoryDatabase(databaseName: "DbContextInMemory")
                        .Options;

            _config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>());

            _mapper = _config.CreateMapper();

            _context = new WeatherForecastInMemoryContext(options);
            
            _service = new WeatherForecastServiceV1(_context, _mapper);
        }

        [Test]
        public async Task AddWeatherForecastV1()
        {

            var weather = new AddWeatherForecastQueryV1
            {
                 Latitude = 100,
                 Longitude = 100,
                 Date = new DateTime(2024, 4, 1, 02, 00, 0),
                 TemperatureC = 100
             };

             await _service.AddWeatherForecast(weather);

            //Assert.IsInstanceOf<OkResult>(actionResult);
            //var okObjectResult = actionResult as OkResult;
            //Assert.IsNotNull(okObjectResult);
            //Assert.IsNotNull(actionResult);
            
        }
    }
}