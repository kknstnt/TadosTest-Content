namespace Content.WebApi.Controllers.Country.Actions.Create
{
    using System.ComponentModel.DataAnnotations;
    using Api.Requests.Abstractions;

    public record CountryCreateRequest : IRequest<CountryCreateResponse>
    {
        [Required]
        public string Name { get; init; }
    }
}