using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TF_Net_IOT_DemoEntityFramework.DAL.Entities;

namespace TF_Net_IOT_DemoEntityFramework.DAL.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User_").HasKey(u => u.Id);

            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);

            builder.Property(u => u.Password).IsRequired();

            builder.HasMany(u => u.Roles).WithMany(r => r.Users);

            builder.HasMany(u => u.Orders).WithOne(o => o.User).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
