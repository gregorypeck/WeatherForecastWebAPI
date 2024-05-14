using Microsoft.EntityFrameworkCore;
using WeatherForecastWebAPI.Models;

namespace WeatherForecastWebAPI.DBContext;

public class WeatherForecastMSSQLDBContext : DbContext
{

    public WeatherForecastMSSQLDBContext(DbContextOptions<WeatherForecastMSSQLDBContext> options)
           : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecastModelV2>()
            .HasKey(c => new { c.Latitude, c.Longitude, c.Date });

        modelBuilder.Entity<WeatherForecastModelV2>().HasData(
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
                    } );

    }

    public DbSet<WeatherForecastModelV2> WeatherForecastV2 { get; set; }
}
