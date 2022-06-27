using AutoMapper;
using Clean.Domain.Entities;
using Clean.Infrastructure.Persistence.DTOs;

namespace Clean.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<HeroDto, Hero>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}