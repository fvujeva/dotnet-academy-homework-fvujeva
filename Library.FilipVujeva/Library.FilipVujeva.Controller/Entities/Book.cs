using Library.FilipVujeva.Contracts.Dtos;

namespace Library.FilipVujeva.Contracts.Entities
{
    public class Book
    {
        public int Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Authors { get; set; } = default!;
        public Genre Genre { get; set; } = default!;
        public int Quantity { get; set; } = default!;
        public List<PersonBook> PersonBooks { get; }

        public Book(int id, string title, string authors, Genre genre, int quantity)
        {
            Id = id;
            Title = title;
            Authors = authors;
            Genre = genre;
            Quantity = quantity;
            if (PersonBooks == null)
            {
                PersonBooks = new List<PersonBook>();
            }
        }

        private Book()
        {
            if (PersonBooks == null)
            {
                PersonBooks = new List<PersonBook>();
            }
        }

        public bool IsAvailable() => this.Quantity > 0;

        public void RemoveFromShelf()
        {
            if (!IsAvailable())
            {
                throw new Exception("Insufficient number of Books!");
            }
            else
            {
                this.Quantity--;
            }
        }

        public void AddToShelf()
        {
            this.Quantity++;
        }

        public BookCatalogDTO ToCatalogDto()
        {
            BookCatalogDTO catalogDto = new BookCatalogDTO()
            {
                Id = this.Id,
                Title = this.Title,
                Authors = this.Authors,
                Genre = this.Genre.ToString(),
                Quantity = this.Quantity,
            };

            return catalogDto;
        }
    }

    public enum Genre
    {
        ActionAndAdventure,
        Classics,
        ComicBook,
        DetectiveAndMystery,
        Fantasy,
        HistoricalFiction,
        Horror,
        LiteraryFiction,
        Romance,
        ScienceFiction,
        ShortStories,
        SuspenseAndThrillers,
        BiographiesAndAutobiographies,
        CookBooks,
        Essays,
        History,
        Memoir,
        Poetry,
        SelfHelp,
        TrueCrime,
        WomenFiction,
    }
}
