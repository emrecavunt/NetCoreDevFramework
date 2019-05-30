using DevFramework.Northwind.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.FirstName).HasColumnName("FirstName");
            builder.Property(x => x.Password).HasColumnName("Password");
            builder.Property(x => x.UserName).HasColumnName("UserName");
            builder.Property(x => x.LastName).HasColumnName("LastName");
        }
    }
}
