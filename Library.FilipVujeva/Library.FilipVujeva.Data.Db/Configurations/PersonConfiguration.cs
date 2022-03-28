using Library.FilipVujeva.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.FilipVujeva.Data.Db.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();

            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
        }
    }
}
