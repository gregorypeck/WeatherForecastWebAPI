using Microsoft.EntityFrameworkCore;
using WeatherForecastWebAPI.DBContext;

namespace WeatherForecastWebAPI.Models
{
    public class WeatherForecastV2DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WeatherForecastMSSQLDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<WeatherForecastMSSQLDBContext>>()))
            {
                // Look for any forecast.
                if (context.WeatherForecastV2.Any())
                {
                    return;   // Data was already seeded
                }

                context.WeatherForecastV2.AddRange(
                    new WeatherForecastModelV2
                    {
                        Latitude = 100,
                        Longitude = 100,
                        Date = new DateTime(2024, 4, 1, 02, 00, 0),
                        TemperatureC = 10
                    },
                    new WeatherForecastModelV2
                    {
                        Latitude = 13,
                        Longitude = 45,
                        Date = new DateTime(2024, 4, 1, 02, 00, 0),
                        TemperatureC = -18
                    },
                    new WeatherForecastModelV2
                    {
                        Latitude = 66,
                        Longitude = 55,
                        Date = new DateTime(2024, 4, 1, 02, 00, 0),
                        TemperatureC = 32
                    },
                    new WeatherForecastModelV2
                    {
                        Latitude = 3,
                        Longitude = 8,
                        Date = new DateTime(2024, 4, 1, 02, 00, 0),
                        TemperatureC = 0
                    },
                    new WeatherForecastModelV2
                    {
                        Latitude = 99,
                        Longitude = 12.34F,
                        Date = new DateTime(2024, 4, 1, 02, 00, 0),
                        TemperatureC = -3
                    },
                    new WeatherForecastModelV2
                    {
                        Latitude = 5.66F,
                        Longitude = 76F,
                        Date = new DateTime(2024, 4, 1, 02, 00, 0),
                        TemperatureC = -72
                    });

                context.SaveChanges();
            }
        }
    }
}
