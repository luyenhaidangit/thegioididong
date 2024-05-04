using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Thegioididong.Api.Contracts.Data.Entities.Common;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Configurations
{
    public class EntityAuditBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityAuditBase<long>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                  .IsRequired()
                  .HasColumnName("id");

            builder.Property(b => b.CreatedAt)
                   .HasColumnName("created_at");

            builder.Property(b => b.UpdatedAt)
                   .HasColumnName("updated_at");
        }
    }
}
