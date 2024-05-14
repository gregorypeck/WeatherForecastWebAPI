namespace WeatherForecastWebAPI.Queries.V2
{
    public class UpdateWeatherForecastQueryV2
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? Date { get; set; }
        public double? TemperatureC { get; set; }
    }
}
