using Microsoft.EntityFrameworkCore;
using WeatherForecastWebAPI.Models;

namespace WeatherForecastWebAPI.DBContext;

public class WeatherForecastInMemoryContext : DbContext
{
    public WeatherForecastInMemoryContext(DbContextOptions<WeatherForecastInMemoryContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecastModelV2>()
            .HasKey(c => new { c.Latitude, c.Longitude, c.Date });

    }

    public DbSet<WeatherForecastModelV1> WeatherForecastV1 { get; set; }
}
