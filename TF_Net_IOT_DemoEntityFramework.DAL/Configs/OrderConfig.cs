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
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order_",o => o.HasCheckConstraint("CK_Order_Discount", "Discount >= 0")).HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.Date).IsRequired().HasColumnType("datetime2");
            builder.Property(o => o.Discount).IsRequired().HasDefaultValue(0);
        }
    }
}
