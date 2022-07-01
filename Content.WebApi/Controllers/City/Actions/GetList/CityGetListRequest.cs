namespace Content.WebApi.Controllers.City.Actions.GetList
{
    using Domain.Filters;
    using Api.Requests.Abstractions;

    public record CityGetListRequest : IRequest<CityGetListResponse>
    {
        // Если объект Pagination не указан, то отдаётся весь список
        public Pagination Pagination { get; set; }
        
        public CityGetListFilter Filter { get; set; }
    }
}