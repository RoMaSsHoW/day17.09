using HomeWork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.Infrastructure.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("authors");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("id");
            builder.Property(a => a.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(100);
            builder.Property(a => a.PhotoName)
                .HasColumnName("photo_name")
                .HasMaxLength(200);

            builder.HasMany(a => a.Books)
                   .WithOne()
                   .HasForeignKey(b => b.AuthorId)
                   .OnDelete(DeleteBehavior.Cascade);

            //builder.HasData(
            //    new Author { Id = 1, Name = "Leo Tolstoy", PhotoName = "tolstoy.jpg" },
            //    new Author { Id = 2, Name = "Fyodor Dostoevsky", PhotoName = "dostoevsky.jpg" },
            //    new Author { Id = 3, Name = "Alexander Pushkin", PhotoName = "pushkin.jpg" }
            //);
        }
    }
}
