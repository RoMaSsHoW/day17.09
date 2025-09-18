using HomeWork.Domain.Entities;

namespace HomeWork.Application.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> FindAllAsync();
        Task<Book?> FindByIdAsync(int id);
        Task<Book?> FindByTitleAsync(string title);
        Task<Book> AddAsync(Book book);
        Task<Book?> UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
}
