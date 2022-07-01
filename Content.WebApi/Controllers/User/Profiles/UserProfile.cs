namespace Content.WebApi.Controllers.User.Profiles
{
    using AutoMapper;
    using Domain.Entities;
    using Dto;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.City,
                    opts => opts.MapFrom(src => src.City))
                .ForPath(
                    dest => dest.City.CountryDto,
                    opts => opts.MapFrom(src => src.City.Country));

            CreateMap<User, UserListItemDto>()
                .ForMember(
                    dest => dest.CityFullName,
                    opts => opts.MapFrom(src => $"{src.City.Country.Name}, {src.City.Name}"));
        }
    }
}
