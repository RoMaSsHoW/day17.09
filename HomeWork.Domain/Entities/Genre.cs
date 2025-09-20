namespace HomeWork.Domain.Entities
{
    public class Genre
    {
        private readonly List<BookGenre> _bookGenres = new();

        public Genre() { }

        private Genre(string name)
        {
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public IReadOnlyCollection<BookGenre> BookGenres => _bookGenres.AsReadOnly();

        public static Genre Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Genre name cannot be empty");

            return new Genre(name);
        }
    }
}
