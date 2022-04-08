using Library.FilipVujeva.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.FilipVujeva.Data.Db.Configurations
{
    public class PersonBookConfiguration : IEntityTypeConfiguration<PersonBook>
    {
        public void Configure(EntityTypeBuilder<PersonBook> builder)
        {
            builder.HasKey(t => new { BookId = t.BookId, PersonId = t.PersonId});

            builder.Property(x => x.DateRented).IsRequired();

            builder.HasOne(x => x.Book).WithMany(y => y.PersonBooks).HasForeignKey("BookId");

            builder.HasOne(x => x.Person).WithMany(y => y.RentedBooks).HasForeignKey("PersonId");
        }
    }
}
