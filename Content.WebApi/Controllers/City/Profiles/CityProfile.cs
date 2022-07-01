namespace Content.WebApi.Controllers.City.Profiles
{
    using AutoMapper;
    using Domain.Entities;
    using Dto;

    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>()
                .ForMember(
                    dest => dest.CountryDto,
                    opts => opts.MapFrom(src => src.Country));

            CreateMap<City, CityListItemDto>();
        }
    }
}
