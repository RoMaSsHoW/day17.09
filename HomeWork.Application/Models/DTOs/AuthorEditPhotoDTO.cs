using Microsoft.AspNetCore.Http;

namespace HomeWork.Application.Models.DTOs
{
    public class AuthorEditPhotoDTO
    {
        public int Id { get; set; }
        public IFormFile? Photo { get; set; }
        public List<BookDTO> Books { get; set; } = new();
    }
}
