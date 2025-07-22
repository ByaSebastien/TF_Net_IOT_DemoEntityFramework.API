using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Net_IOT_DemoEntityFramework.DAL.Entities;

namespace TF_Net_IOT_DemoEntityFramework.DAL.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(p => p.HasCheckConstraint("CK_Product_Price", "Price >= 0"));
            builder.ToTable(p => p.HasCheckConstraint("CK_Product_AlcoholLevel", "AlcoholLevel >= 0"));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasIndex(p => p.Designation).IsUnique();
            builder.Property(p => p.Designation).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.AlcoholLevel).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.Description).HasMaxLength(500);

            builder.HasMany(p => p.OrderLines)
                   .WithOne(ol => ol.Product)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.StockMovements)
                     .WithOne(sm => sm.Product)
                     .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Stock)
                     .WithOne(s => s.Product)
                     .HasForeignKey<Stock>(s => s.ProductId)
                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
