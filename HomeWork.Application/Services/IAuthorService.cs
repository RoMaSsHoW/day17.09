using HomeWork.Application.Models.DTOs;
using HomeWork.Domain.Entities;

namespace HomeWork.Application.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAsync(int pageNumber);
        Task<Author> CreateAsync(AuthorCreateDTO authorDTO);
        Task<Author?> EditAsync(AuthorEditPhotoDTO authorDTO);
        Task DeleteAsync(int id);
    }
}
