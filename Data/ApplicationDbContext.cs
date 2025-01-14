using BTMSAPI.Models;
using Microsoft.EntityFrameworkCore;




namespace BTMSAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<BusinessUnit> BusinessUnit { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<BatteryItem> BatteryItems { get; set; }
        public DbSet<BatteryReleasedItems> BatteryReleasedItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BatteryReleasedItems>()
                .HasOne(b => b.BatteryItem)
                .WithOne()
                .HasForeignKey<BatteryReleasedItems>(b => b.BatteryItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
