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

    }
}
