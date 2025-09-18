using HomeWork.Application.Repositories;
using HomeWork.Domain.Entities;
using HomeWork.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly HomeWorkDbContext _dbContext;

        public BookRepository(HomeWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> FindAllAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book?> FindByIdAsync(int id)
        {
            var book = await _dbContext.Books
                .FirstOrDefaultAsync(b => b.Id == id);

            return book;
        }

        public async Task<Book?> FindByTitleAsync(string title)
        {
            var book = await _dbContext.Books
                .FirstOrDefaultAsync(b => b.Title == title);

            return book;
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> UpdateAsync(Book book)
        {
            var existingBook = await _dbContext.Books.FindAsync(book.Id);
            if (existingBook == null)
                return null;

            _dbContext.Entry(existingBook).CurrentValues.SetValues(book);

            await _dbContext.SaveChangesAsync();
            return existingBook;
        }

        public async Task DeleteAsync(int id)
        {
            var book = _dbContext.Books.Find(id);
            if (book == null)
                throw new InvalidOperationException($"Book with id={id} not found.");

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
