namespace Thegioididong.Api.Contracts.Data.Entities.Common
{
    public abstract class EntityAuditBase<T> : EntityBase<T>, IEntityAuditBase<T>
    {
        //public DateTimeOffset CreatedDate { get; set; }

        //public DateTimeOffset? LastModifiedDate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
