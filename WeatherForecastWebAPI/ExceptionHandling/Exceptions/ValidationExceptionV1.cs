namespace WeatherForecastWebAPI.ExceptionHandling.Exceptions
{
    public class ValidationExceptionV1 : Exception
    {
        public ValidationExceptionV1(string message) : base(message) { }
    }
}
