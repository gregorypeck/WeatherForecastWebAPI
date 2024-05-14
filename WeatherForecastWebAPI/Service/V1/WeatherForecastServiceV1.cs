using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WeatherForecastWebAPI.DBContext;
using WeatherForecastWebAPI.DTO;
using WeatherForecastWebAPI.ExceptionHandling.Exceptions;
using WeatherForecastWebAPI.Models;
using WeatherForecastWebAPI.Queries.V1;

namespace WeatherForecastWebAPI.Service.V1
{
    public class WeatherForecastServiceV1 : IWeatherForecastServiceV1
    {
        private readonly WeatherForecastInMemoryContext _context;
        private readonly IMapper _mapper;

        public WeatherForecastServiceV1(WeatherForecastInMemoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<WeatherForecastDTOV1>> GetWeatherForecastAll()
        {
            var weatherForecast = await _context.WeatherForecastV1.ToListAsync();

            return _mapper.Map<IList<WeatherForecastDTOV1>>(weatherForecast);
        }

        public async Task<WeatherForecastDTOV1> GetWeatherForecast(GetWeatherForecastQueryV1 weatherForecast)
        {
            var weatherForecastModel = _mapper.Map<WeatherForecastModelV1>(weatherForecast);

            var weather = await _context.WeatherForecastV1.Where(x => x.Latitude == weatherForecastModel.Latitude && x.Longitude == weatherForecastModel.Longitude &&
            x.Date == weatherForecastModel.Date).
            FirstOrDefaultAsync();

            return _mapper.Map<WeatherForecastDTOV1>(weather);
        }

        public async Task<WeatherForecastDTOV1> GetWeatherForecastLatest(GetWeatherForecastLatestQueryV1 weatherForecast)
        {

            var weather = await _context.WeatherForecastV1.Where(x => x.Latitude == weatherForecast.Latitude && x.Longitude == weatherForecast.Longitude).OrderByDescending(x => x.Date).FirstOrDefaultAsync();

            return _mapper.Map<WeatherForecastDTOV1>(weather);
        }

        public async Task<IList<WeatherForecastDTOV1>> GetWeatherForecast12HoursFromDate(GetWeatherForecastQueryV1 weatherForecast)
        {
            var weatherForecastModel = _mapper.Map<WeatherForecastModelV1>(weatherForecast);

            var weather = await _context.WeatherForecastV1
                   .Where(x => x.Latitude == weatherForecastModel.Latitude && x.Longitude == weatherForecastModel.Longitude &&
                   x.Date <= weatherForecastModel.Date)
                   .OrderByDescending(p => p.Date)
                   .Take(12)
                   .ToListAsync();

            return _mapper.Map<IList<WeatherForecastDTOV1>>(weather);
        }


        public async Task AddWeatherForecast(AddWeatherForecastQueryV1 weatherForecast)
        {
            var weatherForecastToAdd = _mapper.Map<WeatherForecastModelV1>(weatherForecast);

            //check if there is element with same parameters ex if we adde dpreviously and do nothing
            var weather = await _context.WeatherForecastV1.Where(x => x.Latitude == weatherForecastToAdd.Latitude && x.Longitude == weatherForecastToAdd.Longitude &&
            x.Date == weatherForecastToAdd.Date).AnyAsync();

            if (!weather)
            {
                _context.WeatherForecastV1.Add(weatherForecastToAdd);
                await _context.SaveChangesAsync();

            }
            else
            {
                throw new ValidationExceptionV1("The is already record in DB with (Latitude, Longitude and Date) and we don't add and show this error..");
            }

        }

        public async Task DeleteWeatherForecast(DeleteWeatherForecastQueryV1 weatherForecast)
        {
            var weatherForecastModel = _mapper.Map<WeatherForecastModelV1>(weatherForecast);

            // get entity and delete
            var weather = await _context.WeatherForecastV1.Where(x => x.Latitude == weatherForecastModel.Latitude && x.Longitude == weatherForecastModel.Longitude &&
            x.Date == weatherForecastModel.Date).FirstOrDefaultAsync();

            if (weather != null)
            {
                _context.Remove(weather);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundExceptionV1("There is no resource to delete.");
            }

        }

        public async Task UpdateWeatherForecastTemperature(UpdateWeatherForecastQueryV1 weatherForecast)
        {
            var weatherForecastToUpdate = _mapper.Map<WeatherForecastModelV1>(weatherForecast);

            var weatherForecastModel = await _context.WeatherForecastV1.Where(x => x.Latitude == weatherForecastToUpdate.Latitude && x.Longitude == weatherForecastToUpdate.Longitude &&
            x.Date == weatherForecastToUpdate.Date).FirstOrDefaultAsync();

            if (weatherForecastModel != null)
            {

                weatherForecastModel.TemperatureC = weatherForecastToUpdate.TemperatureC;
                _context.Update(weatherForecastModel);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundExceptionV1("This is an update error. It tell us thata there we want to update weather data that doesn't exists in database.");
            }

        }
    }
}
