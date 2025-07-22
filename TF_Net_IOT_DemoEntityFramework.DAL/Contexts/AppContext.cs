using Microsoft.EntityFrameworkCore;
using TF_Net_IOT_DemoEntityFramework.DAL.Entities;

namespace TF_Net_IOT_DemoEntityFramework.DAL.Contexts
{
    public class AppContext: DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
