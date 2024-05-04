using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thegioididong.Api.Data.Entities;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Configurations
{
    public class TagConfiguration : EntityAuditBaseConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("tags");

            #region Properties
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(120)
                   .HasColumnName("name");

            builder.Property(t => t.AuthorId)
                   .IsRequired()
                   .HasColumnName("author_id");

            builder.Property(t => t.AuthorType)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("author_type")
                   .HasDefaultValue("Botble\\ACL\\Models\\User");

            builder.Property(t => t.Description)
                   .HasMaxLength(400)
                   .HasColumnName("description")
                   .HasDefaultValue("");

            builder.Property(t => t.Status)
                   .IsRequired()
                   .HasMaxLength(60)
                   .HasColumnName("status")
                   .HasDefaultValue("published");
            #endregion
        }
    }
}