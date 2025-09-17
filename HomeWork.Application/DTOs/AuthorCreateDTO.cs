using Microsoft.AspNetCore.Http;

namespace HomeWork.Application.DTOs
{
    public class AuthorCreateDTO
    {
        public string Name { get; init; } = string.Empty;
        public IFormFile? Photo { get; init; }
    }
}
