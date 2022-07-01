namespace Content.WebApi.Controllers.Content.Actions.Rate
{
    using System.ComponentModel.DataAnnotations;
    using Api.Requests.Abstractions;

    public record ContentRateRequest : IRequest
    {
        public long UserId { get; set; }

        [Range(1, 5)]
        public int Rate { get; init; }

        public long ContentId { get; set; }
    }
}