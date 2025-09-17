using Microsoft.AspNetCore.Http;

namespace HomeWork.Application.Services
{
    public interface IFileStorageService
    {
        Task<byte[]?> GetFileAsync(string? fileName);
        Task<string?> SaveFileAsync(IFormFile? file);
        Task<string?> UpdateFileAsync(string? oldFileName, IFormFile? newFile);
        void DeleteFile(string? fileName);
    }
}
