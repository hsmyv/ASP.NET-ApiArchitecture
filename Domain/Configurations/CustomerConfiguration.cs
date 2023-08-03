using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(m => m.FullName).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Age).IsRequired();
            builder.Property(m => m.Address).IsRequired(false).HasMaxLength(300);
            builder.Property(m => m.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.Property(m => m.SoftDelete).HasDefaultValue(false);

        }
    }
}
