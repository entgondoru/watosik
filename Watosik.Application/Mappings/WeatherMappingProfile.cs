using AutoMapper;
using Watosik.Domain.Entities;
using Watosik.Application.DataTransferObjects;

namespace Watosik.Application.Mappings
{
    public class WeatherMappingProfile : Profile
    {
        public WeatherMappingProfile()
        {
            // Mapowanie z WeatherDto na Weather
            CreateMap<WeatherDto, Weather>()
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.Main.Temp))
                .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Main.Humidity))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Weather.FirstOrDefault().Description));
        }
    }
}
