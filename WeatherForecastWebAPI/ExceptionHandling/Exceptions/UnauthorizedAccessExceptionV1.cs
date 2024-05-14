namespace WeatherForecastWebAPI.ExceptionHandling.Exceptions
{
    public class UnauthorizedAccessExceptionV1 : Exception
    {
        public UnauthorizedAccessExceptionV1(string message) : base(message) { }
    }
}
