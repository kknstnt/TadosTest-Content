namespace Content.WebApi.Controllers.User.Dto
{
    using City.Dto;


    public class UserDto
    {
        public long Id { get; init; }

        public string Email { get; init; }

        public CityDto City { get; init; }
    }
}