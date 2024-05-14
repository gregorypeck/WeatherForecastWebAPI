using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeatherForecastWebAPI.DTO;
using WeatherForecastWebAPI.Queries.V1;
using WeatherForecastWebAPI.Service.V1;

namespace WeatherForecastWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastControllerV1 : ControllerBase
    {

        private readonly IWeatherForecastServiceV1 _weatherForecast;

        public WeatherForecastControllerV1(IWeatherForecastServiceV1 weatherForecast)
        {
            _weatherForecast = weatherForecast;
        }

        /// <summary>
        /// Get everything added to DB
        /// </summary>
        /// <response code="200">Return weather</response>
        /// <response code="204">There is no waether </response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [HttpGet("GetWeatherForecastAll")]
        public async Task<IEnumerable<WeatherForecastDTOV1>> GetWeatherForecastAll()
        {
            return await _weatherForecast.GetWeatherForecastAll();

        }

        /// <summary>
        /// Get latest weather forecast Latitude/Longitutde and specific Date 
        /// </summary>
        /// <response code="200">Return weather</response>
        /// <response code="204">There is no waether </response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [HttpGet("GetWeatherForecast")]
        public async Task<WeatherForecastDTOV1> GetWeatherForecast([FromQuery] GetWeatherForecastQueryV1 weather)
        {
            return await _weatherForecast.GetWeatherForecast(weather); 

        }

        /// <summary>
        /// Get latest weather forecast for last 12 hourd Latitude/Longitutde and from specific Date 
        /// </summary>
        /// <response code="200">Return weather</response>
        /// <response code="204">There is no waether </response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [HttpGet("GetWeatherForecast12HoursFromDate")]
        public async Task<IEnumerable<WeatherForecastDTOV1>> GetWeatherForecast12HoursFromDate([FromQuery] GetWeatherForecastQueryV1 weatherForecast)
        {
            return await _weatherForecast.GetWeatherForecast12HoursFromDate(weatherForecast);

        }

        /// <summary>
        /// Get latest weather forecast for Latitude/Longitutde added to DB
        /// </summary>
        /// <response code="200">Return weather</response>
        /// <response code="204">There is no waether </response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [HttpGet("GetWeatherForecastLatest")]
        public async Task<WeatherForecastDTOV1> GetWeatherForecastLatest([FromQuery] GetWeatherForecastLatestQueryV1 weatherForecast)
        {
            return await _weatherForecast.GetWeatherForecastLatest(weatherForecast);

        }

        /// <summary>
        /// Add weather with temp to DB
        /// </summary>
        /// <remarks>Add  to DB!</remarks>
        /// <response code="200">Weather succesfully added to DB</response>
        /// <response code="400">There Weather already exists and we won't add again, but return this error</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost("CreateWeatherForecast")]
        public async Task<IActionResult> PostCreateWeatherForecast(AddWeatherForecastQueryV1 forecast)
        {
            await _weatherForecast.AddWeatherForecast(forecast);

            return Ok();

        }

        /// <summary>
        /// Update data in DB
        /// </summary>
        /// <remarks>Update DB!</remarks>
        /// <response code="200">Weather data succesfully updated to DB</response>
        /// <response code="404">There is no existing weather for key parameters (Latitude, Longitude, Date) to update</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("UpdateWeatherForecast")]
        public async Task<IActionResult> PutUpdateWeatherForecast([FromBody] UpdateWeatherForecastQueryV1 forecast)
        {
             await _weatherForecast.UpdateWeatherForecastTemperature(forecast);

             return Ok();
        }

        /// <summary>
        /// Update temperature in DB
        /// </summary>
        /// <remarks>Add  to DB!</remarks>
        /// <response code="200">Weather data succesfully updated to DB</response>
        /// <response code="404">There is no existing weather for key parameters (Latitude, Longitude, Date) to delete</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("DeleteWeatherForecast")]
        public async Task<IActionResult> DeleteWeatherForecast([FromBody] DeleteWeatherForecastQueryV1 forecast)
        {
             await _weatherForecast.DeleteWeatherForecast(forecast);

             return Ok();

        }

        /// Throw exception to show how it looks
        [HttpPost("PostThrowException")]
        public async Task<IActionResult> PostThrowException()
        {

            throw new Exception("Here is exception");

        }

    }
}
