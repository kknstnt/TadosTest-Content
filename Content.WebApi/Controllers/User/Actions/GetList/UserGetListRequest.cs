namespace Content.WebApi.Controllers.User.Actions.GetList
{
    using Domain.Filters;
    using Api.Requests.Abstractions;

    public record UserGetListRequest : IRequest<UserGetListResponse>
    {
        // Если объект Pagination не указан, то отдаётся весь список
        public Pagination Pagination { get; set; }
        
        public UserGetListFilter Filter { get; set; }
    }
}