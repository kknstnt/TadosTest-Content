namespace Content.WebApi.Controllers.City.Actions.GetList
{
    using Dto;
    using Domain.Filters;
    using Api.Requests.Abstractions;

    public record CityGetListResponse(PaginatedList<CityListItemDto> Page) : IResponse;
}