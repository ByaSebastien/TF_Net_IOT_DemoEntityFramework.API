using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TF_Net_IOT_DemoEntityFramework.DAL.Entities;

namespace TF_Net_IOT_DemoEntityFramework.DAL.Configs
{
    public class StockMovementConfig : IEntityTypeConfiguration<StockMovement>
    {

        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.ToTable(sm => sm.HasCheckConstraint("CK_StockMovement_Quantity", "Quantity >= 1"));
            builder.HasKey(sm => sm.Id);
            builder.Property(sm => sm.MovementType).HasConversion<string>().IsRequired();

            builder.HasOne(sm => sm.Product)
                   .WithMany(p => p.StockMovements)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
