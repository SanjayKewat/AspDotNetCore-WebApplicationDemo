using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //here we define the table property types, validations
            builder.Property(p=>p.Id).IsRequired();
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.Description).IsRequired();
            builder.Property(p=>p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p=>p.PictureUrl).IsRequired();

            //here define relationship with product one to many by using foreign key
            builder.HasOne(b=>b.ProductBrand).WithMany()
            .HasForeignKey(p=>p.ProductBrandId);

            builder.HasOne(t=>t.ProductType).WithMany()
            .HasForeignKey(p=>p.ProductTypeId);
        }
    }
}