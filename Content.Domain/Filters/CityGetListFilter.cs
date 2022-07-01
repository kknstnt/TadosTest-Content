namespace Content.Domain.Filters
{
    public class CityGetListFilter : Filter
    {
        public long? CountryId { get; init; }

        public string Search { get; init; }
    }
}
