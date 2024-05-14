using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WeatherForecastWebAPI.DBContext;
using WeatherForecastWebAPI.DTO;
using WeatherForecastWebAPI.ExceptionHandling.Exceptions;
using WeatherForecastWebAPI.Models;
using WeatherForecastWebAPI.Queries.V2;

namespace WeatherForecastWebAPI.Service.V2
{
    public class WeatherForecastServiceV2 : IWeatherForecastServiceV2
    {
        private readonly WeatherForecastMSSQLDBContext _context;
        private readonly IMapper _mapper;

        public WeatherForecastServiceV2(WeatherForecastMSSQLDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<WeatherForecastDTOV2>> GetWeatherForecastAll()
        {
            var weather = await _context.WeatherForecastV2.ToListAsync();

            return _mapper.Map<IList<WeatherForecastDTOV2>>(weather);
        }

        public async Task<WeatherForecastDTOV2> GetWeatherForecast(GetWeatherForecastQueryV2 weatherForecast)
        {
            var weatherForecastMappedModel = _mapper.Map<WeatherForecastModelV2>(weatherForecast);

            var weather = await _context.WeatherForecastV2.Where(x => x.Latitude == weatherForecastMappedModel.Latitude && x.Longitude == weatherForecastMappedModel.Longitude
            && x.Date == weatherForecastMappedModel.Date).FirstOrDefaultAsync();

            return _mapper.Map<WeatherForecastDTOV2>(weather);
        }

        public async Task<IList<WeatherForecastDTOV2>> GetWeatherForecast12HoursFromDate(GetWeatherForecastQueryV2 weatherForecast)
        {
            var weatherForecastMappedModel = _mapper.Map<WeatherForecastModelV2>(weatherForecast);

            var weather = await _context.WeatherForecastV2
                   .Where(x => x.Latitude == weatherForecastMappedModel.Latitude && x.Longitude == weatherForecastMappedModel.Longitude && 
                   x.Date <= weatherForecastMappedModel.Date)
                   .OrderByDescending(p => p.Date)
                   .Take(12)
                   .ToListAsync();

            return _mapper.Map<IList<WeatherForecastDTOV2>>(weather);
        }

        public async Task<WeatherForecastDTOV2> GetWeatherForecastLatest(GetWeatherForecastLatestQueryV2 weatherForecast)
        {
            var weather = await _context.WeatherForecastV2.Where(x => x.Latitude == weatherForecast.Latitude && x.Longitude == weatherForecast.Longitude).OrderByDescending(x => x.Date).FirstOrDefaultAsync();

            return _mapper.Map<WeatherForecastDTOV2>(weather);
        }

        public async Task AddWeatherForecast(AddWeatherForecastQueryV2 weatherForecast)
        {
            var weatherForecastToAdd = _mapper.Map<WeatherForecastModelV2>(weatherForecast);

            //check if there is element with same parameters ex if we adde dpreviously and do nothing
            var weather = await _context.WeatherForecastV2.Where(x => x.Latitude == weatherForecastToAdd.Latitude && x.Longitude == weatherForecastToAdd.Longitude &&
            x.Date == weatherForecastToAdd.Date).AnyAsync();

            if (!weather)
            {
                _context.WeatherForecastV2.Add(weatherForecastToAdd);
                await _context.SaveChangesAsync();

            }
            else
            {
                throw new ValidationExceptionV1("The is already record in DB with (Latitude, Longitude and Date) and we don't add and show this error..");
            }
        }

        public async Task UpdateWeatherForecastTemperature(UpdateWeatherForecastQueryV2 weatherForecast)
        {

            var weatherForecastModel = _mapper.Map<WeatherForecastModelV2>(weatherForecast);

            var weatherEntity = await _context.WeatherForecastV2.Where(x => x.Latitude == weatherForecastModel.Latitude && x.Longitude == weatherForecastModel.Longitude 
            && x.Date == weatherForecastModel.Date).FirstOrDefaultAsync();

            if (weatherEntity != null)
            {
                weatherEntity.TemperatureC = weatherForecastModel.TemperatureC;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundExceptionV1("This is an update error. It tell us thata there we want to update weather data that doesn't exists in database.");
            }
        }

        public async Task DeleteWeatherForecast(DeleteWeatherForecastQueryV2 weatherForecast)
        {
            var weatherForecastModel = _mapper.Map<WeatherForecastModelV2>(weatherForecast);

            var weatherEntity = await _context.WeatherForecastV2.Where(x => x.Latitude == weatherForecastModel.Latitude && x.Longitude == weatherForecastModel.Longitude 
            && x.Date == weatherForecastModel.Date).FirstOrDefaultAsync();

            if (weatherEntity != null)
            {
                _context.Remove(weatherEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundExceptionV1("There is no resource to delete.");
            }
        }

    }
}
