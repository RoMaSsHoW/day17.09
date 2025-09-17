using HomeWork.Domain.Entities;

namespace HomeWork.Application.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author?> FindByIdAsync(int id);
        Task<Author> AddAsync(Author author);
        Task<Author?> UpdateAsync(Author author);
        Task DeleteAsync(int id);
    }
}
