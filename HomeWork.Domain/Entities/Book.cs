using System.Globalization;

namespace HomeWork.Domain.Entities
{
    public class Book
    {
        private readonly List<BookGenre> _bookGenres = new();

        public Book() { }

        private Book(
            int authorId,
            string title)
        {
            AuthorId = authorId;
            Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
        }

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public IReadOnlyCollection<BookGenre> BookGenres => _bookGenres.AsReadOnly();

        public static Book Create(
            int authorId,
            string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Book title cannot be null or empty.", nameof(title));

            if (authorId <= 0)
                throw new ArgumentException("AuthorId must be a positive integer.", nameof(authorId));

            return new Book(authorId, title);
        }

        public void UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Book title cannot be null or empty.", nameof(title));

            if (Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                return;

            Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
        }
    }
}
