using WeatherForecastWebAPI.DBContext;

namespace WeatherForecastWebAPI.Models
{
    public class WeatherForecastV1DataGenerator
    {
        private readonly WeatherForecastInMemoryContext _context;

        public WeatherForecastV1DataGenerator(WeatherForecastInMemoryContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.WeatherForecastV1.Any())
            {

                _context.WeatherForecastV1.AddRange(
                    new WeatherForecastModelV1
                    {
                        Latitude = 100,
                        Longitude = 100,
                        Date = new DateTime(2024, 4, 1, 02, 00, 0),
                        TemperatureC = 10
                    },
                    new WeatherForecastModelV1
                    {
                        Latitude = 13,
                        Longitude = 45,
                        Date = new DateTime(2024, 4, 1, 02, 00, 0),
                        TemperatureC = -18
                    },
                    new WeatherForecastModelV1
                    {
                        Latitude = 66,
                        Longitude = 55,
                        Date = new DateTime(2024, 4, 1, 02, 00, 0),
                        TemperatureC = 32
                    },
                    new WeatherForecastModelV1
                    {
                        Latitude = 3,
                        Longitude = 8,
                        Date = new DateTime(2024, 4, 1, 02, 00, 0),
                        TemperatureC = 0
                    },
                    new WeatherForecastModelV1
                    {
                        Latitude = 99,
                        Longitude = 12.34F,
                        Date = new DateTime(2024, 4, 1, 02, 00, 0),
                        TemperatureC = -3
                    },
                    new WeatherForecastModelV1
                    {
                        Latitude = 5.66F,
                        Longitude = 76F,
                        Date = new DateTime(2024, 4, 1, 02, 00, 0),
                        TemperatureC = -72
                    });

                _context.SaveChanges();
            }

        }
    }
}
