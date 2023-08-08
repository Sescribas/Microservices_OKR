using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OKR.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Persistence.Database.Configuration
{
    public class CategoryConfiguration
    {
        public CategoryConfiguration(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.Id);
            entityTypeBuilder.Property(x => x.Name);
            entityTypeBuilder.Property(x => x.Description);

            entityTypeBuilder.HasMany(x => x.Products);

        }
    }
}
