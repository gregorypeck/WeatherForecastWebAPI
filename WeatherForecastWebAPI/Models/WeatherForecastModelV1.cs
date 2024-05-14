using Microsoft.EntityFrameworkCore;

namespace WeatherForecastWebAPI.Models
{
    [PrimaryKey(nameof(Date), nameof(Latitude), nameof(Longitude))]
    public class WeatherForecastModelV1  
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public double TemperatureC { get; set; }

    }
}
