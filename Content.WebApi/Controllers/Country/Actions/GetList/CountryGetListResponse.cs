namespace Content.WebApi.Controllers.Country.Actions.GetList
{
    using Dto;
    using Api.Requests.Abstractions;
    using Domain.Filters;

    public record CountryGetListResponse(PaginatedList<CountryListItemDto> Page) : IResponse;
}