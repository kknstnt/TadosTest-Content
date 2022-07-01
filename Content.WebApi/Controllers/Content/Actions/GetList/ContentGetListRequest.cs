namespace Content.WebApi.Controllers.Content.Actions.GetList
{
    using Domain.Filters;
    using Api.Requests.Abstractions;

    public record ContentGetListRequest : IRequest<ContentGetListResponse>
    {
        // Если объект Pagination не указан, то отдаётся весь список
        public Pagination Pagination { get; set; }

        public ContentGetListFilter Filter { get; set; }
    }
}