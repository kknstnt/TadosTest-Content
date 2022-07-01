namespace Content.Domain.Filters
{
    using Enums;
    public class ContentGetListFilter : Filter
    {
        public ContentCategory? Category { get; init; }

        public long? UserId { get; init; }

        // Данное поле должно учитываться в поиске по ссылкам и текстам статей, а не только в названии
        public string Search { get; init; }
    }
}
