using HomeWork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.Infrastructure.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genres");
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnName("id");

            builder.Property(g => g.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(150);
        }
    }
}
