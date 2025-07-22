using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TF_Net_IOT_DemoEntityFramework.DAL.Entities;

namespace TF_Net_IOT_DemoEntityFramework.DAL.Configs
{
    public class OrderLineConfig : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.ToTable(ol => ol.HasCheckConstraint("CK_ORDERLINE_QUANTITY","Quantity >= 1"));
            builder.HasKey(ol => ol.Id);
            builder.Property(ol => ol.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(ol => ol.Quantity).IsRequired();

            builder.HasOne(ol => ol.Order)
                   .WithMany(o => o.OrderLines)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ol => ol.Product)
                     .WithMany(p => p.OrderLines)
                     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
