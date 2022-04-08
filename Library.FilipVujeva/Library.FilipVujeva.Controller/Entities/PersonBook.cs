namespace Library.FilipVujeva.Contracts.Entities
{
    public class PersonBook
    {
        public int PersonId { get; }
        public Person? Person { get; }
        public int BookId { get; }
        public Book Book { get; }
        public DateTime DateRented { get; }

        public PersonBook(Person person, Book book)
        {
            Person = person;
            Book = book;
            DateRented = DateTime.UtcNow;
        }

        public PersonBook()
        {
        }
    }
}
