using FluentValidation;
using WeatherForecastWebAPI.Queries.V2;

namespace WeatherForecastWebAPI.Validators.V2
{
    public class GetWeatherForecastLatestQueryValidatorV2 : AbstractValidator<GetWeatherForecastLatestQueryV2>
    {
        /// <summary>
        /// Validator rules for GetWeatherForecastLatestQueryV2
        /// </summary>
        public GetWeatherForecastLatestQueryValidatorV2()
        {
            RuleFor(x => x.Latitude).NotEmpty().WithMessage("Latitude cannot be blank.");
            RuleFor(x => x.Longitude).NotEmpty().WithMessage("Longitude cannot be blank.");

        }
    }
}
