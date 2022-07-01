namespace Content.WebApi.Controllers.Content.Actions.GetList
{
    using Dto;
    using Domain.Filters;
    using Api.Requests.Abstractions;

    public record ContentGetListResponse(PaginatedList<ContentListItemDto> Page) : IResponse;
}