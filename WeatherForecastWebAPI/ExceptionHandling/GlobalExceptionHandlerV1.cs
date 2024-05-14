using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WeatherForecastWebAPI.ExceptionHandling.Exceptions;

namespace WeatherForecastWebAPI.ExceptionHandling
{
    public class GlobalExceptionFilterV1 : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var statusCode = context.Exception switch
            {
                NotFoundExceptionV1 => StatusCodes.Status404NotFound,

                NoContentExceptionV1 => StatusCodes.Status204NoContent,

                ValidationExceptionV1 => StatusCodes.Status400BadRequest,

                UnauthorizedAccessExceptionV1 => StatusCodes.Status401Unauthorized,

                _ => StatusCodes.Status500InternalServerError
            };

            context.Result = new ObjectResult(new
            {
                error = context.Exception.Message,
                stackTrace = context.Exception.StackTrace
            })
            {
                StatusCode = statusCode
            };
        }
    }
}
