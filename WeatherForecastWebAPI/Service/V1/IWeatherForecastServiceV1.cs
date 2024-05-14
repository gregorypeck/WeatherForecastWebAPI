using WeatherForecastWebAPI.DTO;
using WeatherForecastWebAPI.Queries.V1;

namespace WeatherForecastWebAPI.Service.V1
{
    public interface IWeatherForecastServiceV1
    {
        Task<IList<WeatherForecastDTOV1>> GetWeatherForecastAll();
        Task<WeatherForecastDTOV1> GetWeatherForecast(GetWeatherForecastQueryV1 weatherForecast);
        Task<IList<WeatherForecastDTOV1>> GetWeatherForecast12HoursFromDate(GetWeatherForecastQueryV1 weatherForecast);
        Task<WeatherForecastDTOV1> GetWeatherForecastLatest(GetWeatherForecastLatestQueryV1 weatherForecast);
        Task AddWeatherForecast(AddWeatherForecastQueryV1 weatherForecast);
        Task UpdateWeatherForecastTemperature(UpdateWeatherForecastQueryV1 weatherForecast);
        Task DeleteWeatherForecast(DeleteWeatherForecastQueryV1 weatherForecast);

    }

}
