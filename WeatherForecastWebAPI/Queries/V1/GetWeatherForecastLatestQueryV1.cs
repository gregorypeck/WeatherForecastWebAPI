using System.ComponentModel.DataAnnotations;

namespace WeatherForecastWebAPI.Queries.V1
{
    public class GetWeatherForecastLatestQueryV1
    {
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}
