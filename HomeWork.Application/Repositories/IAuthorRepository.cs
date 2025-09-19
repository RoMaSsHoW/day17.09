using HomeWork.Domain.Entities;

namespace HomeWork.Application.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> FindAllAsync(int pageNumber, int pageSize);
        Task<Author?> FindByIdAsync(int id);
        Task<Author> AddAsync(Author author);
        Task<Author?> UpdateAsync(Author author);
        Task DeleteAsync(int id);
    }
}
