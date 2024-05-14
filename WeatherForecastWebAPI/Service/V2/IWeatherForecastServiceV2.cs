using System.Threading.Tasks;
using WeatherForecastWebAPI.DTO;
using WeatherForecastWebAPI.Queries.V2;

namespace WeatherForecastWebAPI.Service.V2
{
    public interface IWeatherForecastServiceV2
    {
        Task<IList<WeatherForecastDTOV2>> GetWeatherForecastAll();
        Task<WeatherForecastDTOV2> GetWeatherForecast(GetWeatherForecastQueryV2 weather);
        Task<IList<WeatherForecastDTOV2>> GetWeatherForecast12HoursFromDate(GetWeatherForecastQueryV2 weather);
        Task<WeatherForecastDTOV2> GetWeatherForecastLatest(GetWeatherForecastLatestQueryV2 weather);
        Task AddWeatherForecast(AddWeatherForecastQueryV2 weather);
        Task UpdateWeatherForecastTemperature(UpdateWeatherForecastQueryV2 weather);
        Task DeleteWeatherForecast(DeleteWeatherForecastQueryV2 weather);
    }

}
