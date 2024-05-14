namespace WeatherForecastWebAPI.Queries.V2
{
    public class GetWeatherForecastQueryV2
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? Date { get; set; }
    }
}
