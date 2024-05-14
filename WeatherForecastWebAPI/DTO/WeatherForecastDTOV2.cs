using WeatherForecastWebAPI.Validators;

namespace WeatherForecastWebAPI.DTO
{
    //[Validator(typeof(WeatherForecastDTOValidatorV2))]
    public class WeatherForecastDTOV2
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public double TemperatureC { get; set; }
    }
}
