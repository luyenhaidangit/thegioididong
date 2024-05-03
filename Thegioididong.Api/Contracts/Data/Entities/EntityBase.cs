namespace Thegioididong.Api.Contracts.Data.Entities
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
