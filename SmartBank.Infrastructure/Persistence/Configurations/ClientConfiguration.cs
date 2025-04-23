using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Infrastructure.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.PersonId);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(140);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(30);
            builder.Property(x=>x.Email).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Id).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IdType).IsRequired();
            builder.Property(x=>x.BurnDate).IsRequired();
        }
    }
}
