using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thegioididong.Api.Data.Entities;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Configurations
{
    public class PostConfiguration : EntityAuditBaseConfiguration<Post,long>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);

            builder.ToTable("posts");

            #region Indexes
            builder.HasIndex(p => p.Status);
            builder.HasIndex(p => p.AuthorId);
            builder.HasIndex(p => p.AuthorType);
            builder.HasIndex(p => p.CreatedAt);
            #endregion

            #region Properties
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("name");

            builder.Property(p => p.Description)
                   .HasMaxLength(400)
                   .HasColumnName("description");

            builder.Property(p => p.Content)
                   .HasColumnType("longtext")
                   .HasColumnName("content");

            builder.Property(p => p.Status)
                   .IsRequired()
                   .HasMaxLength(60)
                   .HasColumnName("status")
                   .HasDefaultValue("published");

            builder.Property(p => p.AuthorId)
                   .IsRequired()
                   .HasColumnName("author_id");

            builder.Property(p => p.AuthorType)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("author_type")
                   .HasDefaultValue("Botble\\ACL\\Models\\User");

            builder.Property(p => p.IsFeatured)
                   .IsRequired()
                   .HasColumnName("is_featured")
                   .HasDefaultValue(0);

            builder.Property(p => p.Image)
                   .HasMaxLength(255)
                   .HasColumnName("image");

            builder.Property(p => p.Views)
                   .IsRequired()
                   .HasColumnName("views")
                   .HasDefaultValue(0);

            builder.Property(p => p.FormatType)
                   .HasMaxLength(30)
                   .HasColumnName("format_type");
            #endregion
        }
    }
}