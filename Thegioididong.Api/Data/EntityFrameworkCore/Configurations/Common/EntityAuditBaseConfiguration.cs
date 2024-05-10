using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Thegioididong.Api.Contracts.Data.Entities.Common;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Configurations
{
    public class EntityAuditBaseConfiguration<T,K> : IEntityTypeConfiguration<T> where T : EntityAuditBase<K>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                  .IsRequired()
                  .HasColumnName("Id");

            builder.Property(b => b.CreatedAt)
                   .HasColumnName("CreatedAt");

            builder.Property(b => b.UpdatedAt)
                   .HasColumnName("UpdatedAt");
        }
    }
}
