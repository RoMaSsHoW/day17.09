using HomeWork.Domain.Entities;
using HomeWork.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Infrastructure.Data
{
    public class HomeWorkDbContext : DbContext
    {
        public HomeWorkDbContext(DbContextOptions<HomeWorkDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
