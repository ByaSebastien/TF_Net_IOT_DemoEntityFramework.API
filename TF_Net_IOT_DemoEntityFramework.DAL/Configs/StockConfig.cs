using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TF_Net_IOT_DemoEntityFramework.DAL.Entities;

namespace TF_Net_IOT_DemoEntityFramework.DAL.Configs
{
    public class StockConfig : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable(s => s.HasCheckConstraint("CK_Stock_Limit","LimitQuantity >= 0"));
            builder.HasKey(s => s.Id);
            builder.Property(s => s.CurrentQuantity).IsRequired();
            builder.Property(s => s.LimitQuantity).IsRequired(false);

            builder.HasOne(s => s.Product)
            .WithOne(p => p.Stock)
            .HasForeignKey<Stock>(s => s.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}