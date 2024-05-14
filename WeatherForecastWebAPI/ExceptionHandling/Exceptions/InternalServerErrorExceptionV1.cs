namespace WeatherForecastWebAPI.ExceptionHandling.Exceptions
{
    public class InternalServerErrorExceptionV1 : Exception
    {
        public InternalServerErrorExceptionV1(string message) : base(message) { }
    }
}
