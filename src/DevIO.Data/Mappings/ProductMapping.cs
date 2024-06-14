using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder
            .HasKey(x => x.Id)
            .HasName("PK_Products");

        builder
            .Property(x => x.Name)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder
            .Property(x => x.Description)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(300);

        builder
            .Property(x => x.Value)
            .HasPrecision(19, 2);
    }
}
