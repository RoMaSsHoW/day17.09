namespace HomeWork.Domain.Entities
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int GenreId { get; set; }
        public Genre Gener { get; set; }
    }
}
