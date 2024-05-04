using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thegioididong.Api.Contracts.Data.Entities.Location;

namespace Thegioididong.Api.Data.EntityFrameworkCore.Configurations.Common
{
    public class TranslatableConfiguration<T> : IEntityTypeConfiguration<T> where T : Translatable
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(ct => ct.LangCode)
                   .IsRequired()
                   .HasMaxLength(191)
                   .HasColumnName("lang_code");

            builder.Property(ct => ct.Name)
                   .HasMaxLength(255)
                   .HasColumnName("name");

            builder.Property(ct => ct.Description)
                   .HasMaxLength(400)
                   .HasColumnName("description");
        }
    }
}
