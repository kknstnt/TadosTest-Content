namespace Content.WebApi.Controllers.Country.Dto
{
    public record CountryDto
    {
        public long Id { get; init; }
        
        public string Name { get; init; }
    }
}