using HomeWork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.Infrastructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("id");
            builder.Property(b => b.AuthorId)
                .IsRequired()
                .HasColumnName("author_id");
            builder.Property(b => b.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasMaxLength(300);
        }
    }
}
