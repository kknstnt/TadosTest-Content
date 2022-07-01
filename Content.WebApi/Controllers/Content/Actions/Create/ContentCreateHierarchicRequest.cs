namespace Content.WebApi.Controllers.Content.Actions.Create
{
    using System.ComponentModel.DataAnnotations;
    using Api.Requests.Hierarchic.Abstractions;
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;

    public abstract record ContentCreateHierarchicRequest : IHierarchicRequest<ContentCreateHierarchicResponse>
    {
        [Required]
        [HierarchyDiscriminator]
        public ContentCategory Category { get; init; }

        public string Name { get; set; }

        public long UserId { get; set; }
    }
}