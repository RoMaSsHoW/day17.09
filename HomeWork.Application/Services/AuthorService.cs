using HomeWork.Application.DTOs;
using HomeWork.Application.Repositories;
using HomeWork.Domain.Entities;

namespace HomeWork.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IFileStorageService _fileStorageService;

        public AuthorService(
            IAuthorRepository authorRepository,
            IFileStorageService fileStorageService,
            IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
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

        public async Task<Author?> EditAsync(AuthorEditPhotoDTO authorDTO)
        {
            var author = await _authorRepository.FindByIdAsync(authorDTO.Id);
            if (author == null)
                return null;

            var fileName = await _fileStorageService.UpdateFileAsync(author.PhotoName, authorDTO.Photo);

            author.UpdatePhoto(fileName);

            var updatedAuthor = await _authorRepository.UpdateAsync(author);
            if(updatedAuthor == null)
                return null;

            var photoPath = _fileStorageService.GetFilePath(updatedAuthor.PhotoName);

            updatedAuthor.UpdatePhoto(photoPath);

            return updatedAuthor;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
