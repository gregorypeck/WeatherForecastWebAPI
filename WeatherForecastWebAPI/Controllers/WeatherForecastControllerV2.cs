using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastWebAPI.DTO;
using WeatherForecastWebAPI.Queries.V2;
using WeatherForecastWebAPI.Service.V2;


namespace WeatherForecastWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WeatherForecastControllerV2 : ControllerBase
    {

        private readonly IWeatherForecastServiceV2 _weatherForecast;

        public WeatherForecastControllerV2(IWeatherForecastServiceV2 weatherForecast)
        {
            _weatherForecast = weatherForecast;
        }

        /// <summary>
        /// Get everything added to DB
        /// </summary>
        /// <response code="401">Unauthorized</response>
        [ProducesResponseType(401)]
        [HttpGet("GetWeatherForecastAll")]
        public async Task<IEnumerable<WeatherForecastDTOV2>> GetWeatherForecastAll()
        {
            return await _weatherForecast.GetWeatherForecastAll();

        }

        /// <summary>
        /// Get latest weather forecast Latitude/Longitutde and specific Date 
        /// </summary>
        /// <response code="401">Unauthorized</response>
        [ProducesResponseType(401)]
        [HttpGet("GetWeatherForecast")]
        public async Task<WeatherForecastDTOV2> GetWeatherForecast([FromQuery] GetWeatherForecastQueryV2 weatherForecast)
        {
            return await _weatherForecast.GetWeatherForecast(weatherForecast); 
        }

        /// <summary>
        /// Get latest weather forecast for Latitude/Longitutde added to DB
        /// </summary>
        /// <response code="401">Unauthorized</response>
        [ProducesResponseType(401)]
        [HttpGet("GetWeatherForecastLatest")]
        public async Task<WeatherForecastDTOV2> GetWeatherForecastLatest([FromQuery] GetWeatherForecastLatestQueryV2 weatherForecast)
        {
            return await _weatherForecast.GetWeatherForecastLatest(weatherForecast);

        }

        /// <summary>
        /// Get latest weather forecast for last 12 hourd Latitude/Longitutde and from specific Date 
        /// </summary>
        /// <response code="401">Unauthorized</response>
        [ProducesResponseType(401)]
        [HttpGet("GetWeatherForecast12HoursFromDate")]
        public async Task<IEnumerable<WeatherForecastDTOV2>> GetWeatherForecast12HoursFromDate([FromQuery] GetWeatherForecastQueryV2 weatherForecast)
        {
            return await _weatherForecast.GetWeatherForecast12HoursFromDate(weatherForecast);

        }

        /// <summary>
        /// Add weather with temp to DB
        /// </summary>
        /// <remarks>Add  to DB!</remarks>
        /// <response code="200">Weather succesfully added to DB</response>
        /// <response code="400">There Weather already exists and we won't add again, but return this error</response>
        /// <response code="401">Unauthorized</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPost("CreateWeatherForecast")]
        public async Task<IActionResult> PostCreateWeatherForecast([FromBody] AddWeatherForecastQueryV2 forecast)
        {
            await _weatherForecast.AddWeatherForecast(forecast);

            return Ok();

        }

        /// <summary>
        /// Update data in DB
        /// </summary>
        /// <remarks>Update DB!</remarks>
        /// <response code="200">Weather data succesfully updated to DB</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">There is no existing weather for key parameters (Latitude, Longitude, Date) to update</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [HttpPut("UpdateWeatherForecast")]
        public async Task<IActionResult> PutUpdateWeatherForecas(UpdateWeatherForecastQueryV2 weatherForecast)
        {
            await _weatherForecast.UpdateWeatherForecastTemperature(weatherForecast);

            return Ok();
        }

        /// <summary>
        /// Update temperature in DB
        /// </summary>
        /// <remarks>Add  to DB!</remarks>
        /// <response code="200">Weather data succesfully updated to DB</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">There is no existing weather for key parameters (Latitude, Longitude, Date) to delete</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [HttpDelete("DeleteWeatherForecast")]
        public async Task<IActionResult> DeleteWeatherForecast(DeleteWeatherForecastQueryV2 weatherForecast)
        {
            await _weatherForecast.DeleteWeatherForecast(weatherForecast);
            
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
