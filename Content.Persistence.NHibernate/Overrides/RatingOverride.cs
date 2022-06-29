namespace Content.Persistence.NHibernate.Overrides
{
    using Domain.ValueObjects;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Types;


    public class RatingOverride : IAutoMappingOverride<ContentRating>
    {
        public void Override(AutoMapping<ContentRating> mapping)
        {
            mapping.Map(x => x.DateTimeUtc).CustomType<SqliteCustomUtcDateTimeType>();
        }
    }
}