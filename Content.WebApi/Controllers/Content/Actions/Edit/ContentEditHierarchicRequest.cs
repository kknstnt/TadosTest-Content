namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using Api.Requests.Hierarchic.Abstractions;
    using System.ComponentModel.DataAnnotations;
    using Common.DataAnnotations.Hierarchy;
    using Domain.Enums;

    public abstract record ContentEditHierarchicRequest : IHierarchicRequest
    {
        [Required]
        [HierarchyDiscriminator]
        public ContentCategory Category { get; init; }

        public long Id { get; set; }

        public string Name { get; set; }
    }
}