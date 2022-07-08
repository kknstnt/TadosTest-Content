namespace Content.WebApi.Controllers.City.Profiles
{
    using AutoMapper;
    using Domain.Entities;
    using Dto;

    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<City, CityListItemDto>();
        }
    }
}
