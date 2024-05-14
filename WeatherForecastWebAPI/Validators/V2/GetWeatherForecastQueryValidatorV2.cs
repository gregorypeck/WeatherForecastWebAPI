using FluentValidation;
using WeatherForecastWebAPI.Queries.V2;

namespace WeatherForecastWebAPI.Validators.V2
{
    public class GetWeatherForecastQueryValidatorV2 : AbstractValidator<GetWeatherForecastQueryV2>
    {
        /// <summary>
        /// Validator rules for GetWeatherForecastQueryV2
        /// </summary>
        public GetWeatherForecastQueryValidatorV2()
        {
            RuleFor(x => x.Latitude).NotEmpty().WithMessage("Latitude cannot be blank.");
            RuleFor(x => x.Longitude).NotEmpty().WithMessage("Longitude cannot be blank.");
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("The Date cannot be blank.");

        }
    }
}
