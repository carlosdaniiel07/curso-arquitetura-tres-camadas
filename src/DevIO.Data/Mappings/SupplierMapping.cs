using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings;

public class SupplierMapping : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers");

        builder
            .HasKey(x => x.Id)
            .HasName("PK_Suppliers");

        builder
            .HasIndex(x => x.Document)
            .IsUnique()
            .HasDatabaseName("IX_Suppliers_Document");

        builder
            .Property(x => x.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder
            .Property(x => x.Document)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(14);

        builder
            .HasOne(x => x.Address)
            .WithOne(y => y.Supplier)
            .HasForeignKey<Address>(y => y.SupplierId)
            .HasConstraintName("FK_Addresses_Suppliers")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(x => x.Products)
            .WithOne(y => y.Supplier)
            .HasForeignKey(y => y.SupplierId)
            .HasConstraintName("FK_Products_Suppliers");
    }
}
