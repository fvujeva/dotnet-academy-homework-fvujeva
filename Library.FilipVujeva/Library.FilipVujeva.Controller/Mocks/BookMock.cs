using Library.FilipVujeva.Contracts.Entities;

namespace Library.FilipVujeva.Contracts.Mocks
{
    public static class BookMock
    {
        public static Book Build(int quantity = 5)
        {
            return new Book(5, "test", "test", Genre.Classics, quantity);
        }

        public static List<Book> BuildMore(int quantity)
        {
            var books = new List<Book>();

            for (int i = 0; i < quantity; i++)
            {
                books.Add(new Book(i, "test", "test", Genre.Classics, quantity));
            }

            return books;
        }
    }
}
