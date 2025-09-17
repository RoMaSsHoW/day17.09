using HomeWork.Application.DTOs;

namespace HomeWork.Application.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDTO>> GetAllAsync();
        Task<AuthorDTO> CreateAsync(AuthorCreateDTO authorDTO);
        Task<AuthorDTO?> UpdateAsync(AuthorDTO authorDTO);
    }
}
