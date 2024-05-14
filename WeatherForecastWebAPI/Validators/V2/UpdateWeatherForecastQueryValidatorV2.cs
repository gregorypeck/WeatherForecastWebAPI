using FluentValidation;
using WeatherForecastWebAPI.Queries.V2;

namespace WeatherForecastWebAPI.Validators.V2
{
    public class UpdateWeatherForecastQueryValidatorV2 : AbstractValidator<UpdateWeatherForecastQueryV2>
    {
        /// <summary>
        /// Validator rules for UpdateWeatherForecastQueryV2
        /// </summary>
        public UpdateWeatherForecastQueryValidatorV2()
        {
            RuleFor(x => x.Latitude).NotEmpty().WithMessage("Latitude cannot be blank.");
            RuleFor(x => x.Longitude).NotEmpty().WithMessage("Longitude cannot be blank.");
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("The Date cannot be blank.");
            RuleFor(x => x.TemperatureC)
                .NotEmpty()
                .WithMessage("The Temperatur cannot be empty.")
                .GreaterThanOrEqualTo(-100)
                .WithMessage("The Temperatur cannot be less than -100C.")
                .LessThanOrEqualTo(100)
                .WithMessage("The Temperatur cannot be more than 100C.");

        }
    }
}
