using Library.FilipVujeva.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.FilipVujeva.Data.Db.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired();

            builder.Property(x => x.Authors).IsRequired();

            builder.Property(x => x.Quantity).IsRequired();

            builder.Property(x => x.Genre).IsRequired();
        }
    }
}
