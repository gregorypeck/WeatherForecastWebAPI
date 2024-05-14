using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace WeatherForecastWebAPI.Exceptions
{
    public class UnhandledExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public UnhandledExceptionFilterAttribute() 
        {
        }
    
        public override void OnException(ExceptionContext context)
        {
            var customMessage = "Here is custom message for unhandled exception. " + context.Exception.Message;
    
            // Customize this object to fit your needs
            var result = new ObjectResult(new
            {
                customMessage, // Or a different generic message
                context.Exception.Source,
                ExceptionType = context.Exception.GetType().FullName,
            })
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
    
            // Set the result
            context.Result = result;
        }
    }
    
}
