namespace Content.WebApi.Controllers.User.Actions.GetList
{
    using Dto;
    using Domain.Filters;
    using Api.Requests.Abstractions;

    public record UserGetListResponse(PaginatedList<UserListItemDto> Page) : IResponse;
}