using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OKR.Common.Domain;

namespace OKR.Common.Persistence.Database.Configuration
{
    internal class ProductStockConfiguration
    {
        public ProductStockConfiguration(EntityTypeBuilder<ProductStock> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.Id);
            entityTypeBuilder.Property(x => x.ProductId);
            entityTypeBuilder.Property(x => x.SellingPrice);
            entityTypeBuilder.Property(x => x.Quantity);
            entityTypeBuilder.Property(x => x.Discount);
            entityTypeBuilder.Property(x => x.LastUpdated);
            entityTypeBuilder.HasOne(x => x.Product);
        }
    }
}