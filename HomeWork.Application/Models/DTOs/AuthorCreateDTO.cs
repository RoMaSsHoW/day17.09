using Microsoft.AspNetCore.Http;

namespace HomeWork.Application.Models.DTOs
{
    public class AuthorCreateDTO
    {
        public string Name { get; init; } = string.Empty;
        public IFormFile? Photo { get; init; }
    }
}
