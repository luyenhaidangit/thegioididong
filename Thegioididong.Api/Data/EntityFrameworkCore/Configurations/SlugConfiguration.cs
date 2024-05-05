using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thegioididong.Api.Data.Entities;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Configurations
{
    public class SlugConfiguration : EntityAuditBaseConfiguration<Slug, long>
    {
        public override void Configure(EntityTypeBuilder<Slug> builder)
        {
            base.Configure(builder);

            builder.ToTable("slugs");

            #region Index
            builder.HasIndex(b => b.ReferenceId);
            #endregion

            #region Columns
            builder.Property(b => b.Key)
                   .IsRequired()
                   .HasColumnName("key");

            builder.Property(b => b.ReferenceId)
                   .IsRequired()
                   .HasColumnName("reference_id");

            builder.Property(b => b.ReferenceType)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("reference_type");

            builder.Property(b => b.Prefix)
                   .HasMaxLength(120)
                   .HasColumnName("prefix")
                   .HasDefaultValue("");
            #endregion
        }
    }
}
