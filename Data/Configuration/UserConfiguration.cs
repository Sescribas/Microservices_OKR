using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Persistence.Database.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<User> entityTypeBuilder) 
        {

            entityTypeBuilder.HasIndex(x => x.Id);

            entityTypeBuilder.Property(x => x.UserName);
            entityTypeBuilder.Property(x => x.Password);
            entityTypeBuilder.Property(x => x.Email);
            entityTypeBuilder.Property(x => x.Dni);
        }  
    }
}
