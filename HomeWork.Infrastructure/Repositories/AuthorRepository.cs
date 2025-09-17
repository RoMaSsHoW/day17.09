using HomeWork.Application.Repositories;
using HomeWork.Domain.Entities;
using HomeWork.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly HomeWorkDbContext _dbContext;

        public AuthorRepository(HomeWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author?> FindByIdAsync(int id)
        {
            var author = await _dbContext.Authors
                .Include(b => b.Books)
                .FirstOrDefaultAsync(a => a.Id == id);

            return author;
        }

        public async Task<Author> AddAsync(Author author)
        {
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
            return author;
        }

        public async Task<Author?> UpdateAsync(Author author)
        {
            var existingAuthor = await _dbContext.Authors.FindAsync(author.Id);
            if (existingAuthor == null)
                return null;

            _dbContext.Entry(existingAuthor).CurrentValues.SetValues(author);

            await _dbContext.SaveChangesAsync();
            return existingAuthor;
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            if (author == null)
                throw new InvalidOperationException($"Author with id={id} not found.");

            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }
    }
}
