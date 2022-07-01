namespace Content.WebApi.Controllers.Content.Dto
{
    using User.Dto;
    using Domain.Enums;

    public abstract class ContentDto
    {
        public long Id { get; init; }

        public ContentCategory Category { get; init; }

        public UserDto Creator { get; init; }

        public string Name { get; init; }
        
        public decimal AverageRating { get; init; }
    }
}