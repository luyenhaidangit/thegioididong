namespace Thegioididong.Api.Contracts.Data.Entities.Common
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
