namespace Content.WebApi.Controllers.Content.Dto
{
    using User.Dto;
    using Domain.Enums;

    public abstract class ContentListItemDto
    {
        public long Id { get; init; }

        public ContentCategory Category { get; init; }

        public UserListItemDto Creator { get; init; }

        public string Name { get; init; }
        
        public decimal AverageRating { get; init; }
    }
}