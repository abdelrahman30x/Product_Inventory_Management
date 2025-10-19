using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMS.DAL.Models.Product;

namespace PIMS.DAL.Configuration
{
    public class ProductConiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id)
                   .UseIdentityColumn(10, 10);

            builder.Property(p => p.Name)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(p => p.Price).HasColumnType("decimal(10,3)");
            builder.Property(p => p.Quantity).HasColumnType("int");


            builder.HasOne(e => e.Category)
                              .WithMany(d => d.Products)
                              .HasForeignKey(e => e.CategoryId)
                              .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
