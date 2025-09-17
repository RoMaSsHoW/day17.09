namespace HomeWork.Application.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public byte[]? Photo { get; init; }
    }
}
