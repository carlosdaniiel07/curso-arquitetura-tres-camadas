using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings;

public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");

        builder
            .HasKey(x => x.Id)
            .HasName("PK_Addresses");

        builder
            .Property(x => x.Street)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(100);

        builder
            .Property(x => x.Number)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(50);

        builder
            .Property(x => x.Complement)
            .IsUnicode(false)
            .HasMaxLength(200);

        builder
            .Property(x => x.ZipCode)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(30);

        builder
            .Property(x => x.Neighborhood)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(80);

        builder
            .Property(x => x.City)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(100);

        builder
            .Property(x => x.State)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(2)
            .IsFixedLength();
    }
}
