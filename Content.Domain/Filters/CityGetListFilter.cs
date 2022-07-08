namespace Content.Domain.Filters
{
    public class CityGetListFilter : IFilter
    {
        public long? CountryId { get; init; }

        public string Search { get; init; }
    }
}
