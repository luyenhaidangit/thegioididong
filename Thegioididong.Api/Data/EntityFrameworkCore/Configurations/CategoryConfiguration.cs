using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Thegioididong.Api.Data.Entities;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Configurations
{
    public class CategoryConfiguration : EntityAuditBaseConfiguration<Category,long>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.ToTable("Categories");

            #region Indexes
            builder.HasIndex(b => b.ParentId);

            builder.HasIndex(b => b.Status);

            builder.HasIndex(b => b.CreatedAt);
            #endregion

            #region Properties
            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(120)
                   .HasColumnName("name");

            builder.Property(b => b.ParentId)
                   .IsRequired()
                   .HasColumnName("parent_id")
                   .HasDefaultValue(0);

            builder.Property(b => b.Description)
                   .HasMaxLength(400)
                   .HasColumnName("description");

            builder.Property(b => b.Status)
                   .IsRequired()
                   .HasMaxLength(60)
                   .HasColumnName("status")
                   .HasDefaultValue("published");

            builder.Property(b => b.AuthorId)
                   .IsRequired()
                   .HasColumnName("author_id");

            builder.Property(b => b.AuthorType)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("author_type")
                   .HasDefaultValue("Botble\\ACL\\Models\\User");

            builder.Property(b => b.Icon)
                   .HasMaxLength(60)
                   .HasColumnName("icon");

            builder.Property(b => b.Order)
                   .IsRequired()
                   .HasColumnName("order")
                   .HasDefaultValue(0);

            builder.Property(b => b.IsFeatured)
                   .IsRequired()
                   .HasColumnName("is_featured")
                   .HasDefaultValue(0);

            builder.Property(b => b.IsDefault)
                   .IsRequired()
                   .HasColumnName("is_default")
                   .HasDefaultValue(0);
            #endregion

            #region Relationships
            builder.HasMany(c => c.Slugs).WithOne().HasForeignKey(s => s.ReferenceId);
            #endregion
        }
    }
}
