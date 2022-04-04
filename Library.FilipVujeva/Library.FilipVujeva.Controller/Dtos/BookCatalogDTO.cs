using Library.FilipVujeva.Contracts.Entities;

namespace Library.FilipVujeva.Contracts.Dtos
{
    public class BookCatalogDTO
    {
        public int Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Authors { get; set; } = default!;
        public string Genre { get; set; } = default!;
        public int Quantity { get; set; } = default!;
    }
}
