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

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            var authors = await _authorRepository.FindAllAsync();

            var result = new List<Author>();
            foreach (var author in authors)
            {
                var photoPath = _fileStorageService.GetFilePath(author.PhotoName);

                author.UpdatePhoto(photoPath);

                result.Add(author);
            }

            return result;
        }

        public async Task<Author> CreateAsync(AuthorCreateDTO authorDTO)
        {
            var fileName = await _fileStorageService.SaveFileAsync(authorDTO.Photo);

            var author = Author.Create(authorDTO.Name, fileName);

            await _authorRepository.AddAsync(author);

            var photoPath = _fileStorageService.GetFilePath(author.PhotoName);

            author.UpdatePhoto(photoPath);

            return author;
        }

        public Task<Author?> UpdateAsync(Author authorDTO)
        {
            throw new NotImplementedException();
        }
    }
}
