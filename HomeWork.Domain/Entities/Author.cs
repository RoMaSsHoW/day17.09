using System.Globalization;

namespace HomeWork.Domain.Entities
{
    public class Author
    {
        private readonly List<Book> _books = new();

        public Author() { }

        private Author(string name, string? photoName)
        {
            Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
            PhotoName = photoName;
        }

        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? PhotoName { get; private set; } = string.Empty;
        public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

        public static Author Create(
            string name,
            string? photoName)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Author name cannot be null or empty.", nameof(name));

            return new Author(name, photoName);
        }

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");

            if (_books.Any(b => b.Equals(book)))
                throw new InvalidOperationException($"The book '{book.Title}' is already associated with this author.");

            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");

            if (!_books.Remove(book))
                throw new InvalidOperationException($"The book '{book.Title}' is not associated with this author.");
        }

        public void UpdatePhoto(string? photoName)
        {
            if (PhotoName == photoName)
                return;

            PhotoName = photoName;
        }
    }
}
