namespace WeatherForecastWebAPI.ExceptionHandling.Exceptions
{
    public class NotFoundExceptionV1 : Exception
    {
        public NotFoundExceptionV1(string message) : base(message) { }
    }
}
