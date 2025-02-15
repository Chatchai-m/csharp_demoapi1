using _1Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Infra.Database.Configurations
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            //builder
            //    .HasKey(a => a.Id);

            //builder
            //    .Property(m => m.Name)
            //    .IsRequired()
            //    .HasMaxLength(50);

            //builder
            //    .Property(m => m.Description)
            //    .HasMaxLength(255);

            builder.ToTable("token");
        }
    }
}
