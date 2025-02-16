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
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
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

            // builder.HasMany(e => e.Tokens)
            // .WithOne(e => e.User)
            // .HasForeignKey(e => e.user_id)
            // .HasPrincipalKey(e => e.id);
            // builder.ToTable("user");
        }
    }
}
