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
            //used for modification of Entity Framework Migrations
            
            builder.Property(p=> p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p=> p.Description).IsRequired();
            builder.Property(p=>p.Price).HasColumnType("dedimal(18,2)");
            builder.Property(p=>p.PictureUrl).IsRequired();
            builder.HasOne(b=>b.ProductBrand).WithMany() //each brand can associated with products
                .HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(t=>t.ProductType).WithMany()
                .HasForeignKey(p=>p.ProductTypeId);
        }
    }


}