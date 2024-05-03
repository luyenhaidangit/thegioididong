namespace Thegioididong.Api.Contracts.Data.Entities
{
    public abstract class EntityAuditBase<T> : EntityBase<T>, IEntityAuditBase<T>
    {
        //public DateTimeOffset CreatedDate { get; set; }

        //public DateTimeOffset? LastModifiedDate { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
