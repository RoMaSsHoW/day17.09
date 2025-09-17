using HomeWork.Application.Services;

namespace HomeWork.Api.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _imageFolderPath;

        public FileStorageService(IWebHostEnvironment env)
        {
            _imageFolderPath = Path.Combine(env.WebRootPath, "images");
            if (!Directory.Exists(_imageFolderPath))
                Directory.CreateDirectory(_imageFolderPath);
        }

        public async Task<byte[]?> GetFileAsync(string? fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;

            var filePath = Path.Combine(_imageFolderPath, fileName);
            if (!File.Exists(filePath))
                return null;

            return await File.ReadAllBytesAsync(filePath);
        }

        public async Task<string?> SaveFileAsync(IFormFile? file)
        {
            if (file == null || file.Length == 0)
                return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_imageFolderPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return fileName;
        }

        public async Task<string?> UpdateFileAsync(string? oldFileName, IFormFile? newFile)
        {
            if (newFile == null || newFile.Length == 0)
                return oldFileName;

            DeleteFile(oldFileName);

            return await SaveFileAsync(newFile);
        }

        public void DeleteFile(string? fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var filePath = Path.Combine(_imageFolderPath, fileName);
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
        }
    }
}
