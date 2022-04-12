using Library.FilipVujeva.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.FilipVujeva.Data.Db.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Person).WithOne(x => x.Adress).HasForeignKey<Person>(x => x.Id);

            builder.Property(x => x.Country);

            builder.Property(x => x.City);

            builder.Property(x => x.Street);
        }
    }
}
