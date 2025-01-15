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
        public DbSet<BatteryReturnedItems> BatteryReturnedItems { get; set; }
        public DbSet<TireItem> TireItems { get; set; }
        public DbSet<TireReleasedItems> TireReleasedItems { get; set; }
        public DbSet<TireReturnedItems> TireReturnedItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BatteryReleasedItems>()
                .HasOne(b => b.BatteryItem)
                .WithOne()
                .HasForeignKey<BatteryReleasedItems>(b => b.BatteryItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BatteryReleasedItems>()
                .Property(b => b.ReleasedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<BatteryReturnedItems>()
                .HasOne(b => b.BatteryReleasedItem)
                .WithOne()
                .HasForeignKey<BatteryReturnedItems>(b => b.BatteryReleasedItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TireReleasedItems>()
                .HasOne(t => t.TireItem)
                .WithOne()
                .HasForeignKey<TireReleasedItems>(t => t.TireItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TireReturnedItems>()
                .HasOne(t => t.TireReleasedItems)
                .WithOne()
                .HasForeignKey<TireReturnedItems>(t => t.TireReleasedId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
