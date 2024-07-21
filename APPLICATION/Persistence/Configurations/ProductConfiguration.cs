
using DOMAIN.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APPLICATION.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property((product) => product.Name).HasMaxLength(100).IsRequired();
            builder.Property((product) => product.Description).HasMaxLength(500).IsRequired();
            builder.Property((product) => product.Stock).IsRequired();
            builder.Property((product) => product.Image).IsRequired();
            builder.Property((product)=>product.Price).HasColumnType("decimal(18, 2)").IsRequired();

            builder.HasOne((product) => product.Brand)
                .WithMany()
                .HasForeignKey((product) => product.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne((product) => product.Category)
                .WithMany()
                .HasForeignKey((product) => product.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
