using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OKR.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Persistence.Database.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.Id);
            entityTypeBuilder.Property(x => x.Name);
            entityTypeBuilder.Property(x => x.Description);
            entityTypeBuilder.Property(x => x.Brand);
            entityTypeBuilder.Property(x => x.FabricationDate);
            entityTypeBuilder.Property(x => x.ExpirationDate);
            entityTypeBuilder.Property(x => x.Category);
                             //.WithMany(c => c.Products)
                             //.HasForeignKey(p => p.CategoryId);
        }
    }
}
