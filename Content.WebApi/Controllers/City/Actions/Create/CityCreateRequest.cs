namespace Content.WebApi.Controllers.City.Actions.Create
{
    using System.ComponentModel.DataAnnotations;
    using Api.Requests.Abstractions;

    public record CityCreateRequest : IRequest<CityCreateResponse>
    {
        public string Name { get; set; }

        public long CountryId { get; set; }
    }
}