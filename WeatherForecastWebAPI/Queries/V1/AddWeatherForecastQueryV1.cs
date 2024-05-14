using System.ComponentModel.DataAnnotations;

namespace WeatherForecastWebAPI.Queries.V1
{
    public class AddWeatherForecastQueryV1
    {
        [Required]
        public double? Latitude { get; set; }

        [Required]
        public double? Longitude { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        [Range(-100,102)]
        public double? TemperatureC { get; set; }

    }
}
