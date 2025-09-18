using HomeWork.Application.Services;

namespace HomeWork.Api.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _imageFolderPath;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileStorageService(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _imageFolderPath = Path.Combine(env.WebRootPath, "images");
            if (!Directory.Exists(_imageFolderPath))
                Directory.CreateDirectory(_imageFolderPath);

            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetFilePath(string? fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
                return null;

            var request = httpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";

            return $"{baseUrl}/images/{fileName}";
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
