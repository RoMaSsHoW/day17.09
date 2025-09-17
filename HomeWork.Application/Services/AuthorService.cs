using HomeWork.Application.DTOs;
using HomeWork.Application.Repositories;
using HomeWork.Domain.Entities;

namespace HomeWork.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IFileStorageService _fileStorageService;

        public AuthorService(
            IAuthorRepository authorRepository,
            IFileStorageService fileStorageService)
        {
            _authorRepository = authorRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAsync()
        {
            var authors = await _authorRepository.FindAllAsync();

            var result = new List<AuthorDTO>();
            foreach (var author in authors)
            {
                var photoBytes = await _fileStorageService.GetFileAsync(author.PhotoName);

                result.Add(new AuthorDTO
                {
                    Id = author.Id,
                    Name = author.Name,
                    Photo = photoBytes
                });
            }

            return result;
        }

        public async Task<AuthorDTO> CreateAsync(AuthorCreateDTO authorDTO)
        {
            var fileName = await _fileStorageService.SaveFileAsync(authorDTO.Photo);

            var author = Author.Create(authorDTO.Name, fileName);

            await _authorRepository.AddAsync(author);

            byte[]? photoBytes = null;
            if (!string.IsNullOrEmpty(fileName))
            {
                photoBytes = await _fileStorageService.GetFileAsync(fileName);
            }

            return new AuthorDTO
            {
                Id = author.Id,
                Name = author.Name,
                Photo = photoBytes
            };
        }

        public Task<AuthorDTO?> UpdateAsync(AuthorDTO authorDTO)
        {
            throw new NotImplementedException();
        }
    }
}
