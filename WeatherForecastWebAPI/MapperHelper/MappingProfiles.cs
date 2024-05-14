using AutoMapper;
using WeatherForecastWebAPI.DTO;
using WeatherForecastWebAPI.Models;
using WeatherForecastWebAPI.Queries.V1;
using WeatherForecastWebAPI.Queries.V2;

namespace WeatherForecastWebAPI.MapperHelper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<WeatherForecastModelV1, WeatherForecastDTOV1>();
            CreateMap<WeatherForecastDTOV1, WeatherForecastModelV1>()
              .ForMember(x => x.Date,
               opt => opt.MapFrom(src => DateTime.Parse(src.Date.ToString("yyyy-MM-ddTHH:00:00Z"))));
           
            
            CreateMap<AddWeatherForecastQueryV1, WeatherForecastModelV1>()
                       .ForMember(x => x.Date, opt => opt.MapFrom(src =>DateTime.Parse(src.Date.GetValueOrDefault().ToString("yyyy-MM-ddTHH:00:00Z"))));
            CreateMap<UpdateWeatherForecastQueryV1, WeatherForecastModelV1>()
                      .ForMember(x => x.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date.ToString("yyyy-MM-ddTHH:00:00Z"))));
            CreateMap<DeleteWeatherForecastQueryV1, WeatherForecastModelV1>()
                      .ForMember(x => x.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date.ToString("yyyy-MM-ddTHH:00:00Z"))));
            CreateMap<GetWeatherForecastQueryV1, WeatherForecastModelV1>()
                      .ForMember(x => x.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date.ToString("yyyy-MM-ddTHH:00:00Z"))));

            CreateMap<WeatherForecastModelV2, WeatherForecastDTOV2>();
            CreateMap<WeatherForecastDTOV2, WeatherForecastModelV2>();

            CreateMap<AddWeatherForecastQueryV2, WeatherForecastModelV2>()
                      .ForMember(x => x.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date.GetValueOrDefault().ToString("yyyy-MM-ddTHH:00:00Z"))));
            CreateMap<UpdateWeatherForecastQueryV2, WeatherForecastModelV2>()
                      .ForMember(x => x.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date.GetValueOrDefault().ToString("yyyy-MM-ddTHH:00:00Z"))));
            CreateMap<DeleteWeatherForecastQueryV2, WeatherForecastModelV2>()
                      .ForMember(x => x.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date.GetValueOrDefault().ToString("yyyy-MM-ddTHH:00:00Z"))));
            CreateMap<GetWeatherForecastQueryV2, WeatherForecastModelV2>()
                      .ForMember(x => x.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date.GetValueOrDefault().ToString("yyyy-MM-ddTHH:00:00Z"))));

        }
    }
}
