using Ciel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ciel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Catalog>()
                .HasData(
                    new Catalog("Околоочна зона") { Id=1 },
                    new Catalog("Вежди и мигли") { Id=2 },
                    new Catalog("Устни") { Id=3 },
                    new Catalog("Цялостна грижа") { Id=4 }
                );
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Catalog> Catalogs { get; set; }
      
        public DbSet<Review> Reviews { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<Order_Product> Order_Product { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
