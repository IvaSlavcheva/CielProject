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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Catalog>()
                .HasData(
                   new Catalog() { Id = 1, CatalogName = "Околоочна зона" },
                   new Catalog() { Id = 2, CatalogName = "Вежди и мигли" },
                   new Catalog() { Id = 3, CatalogName = "Устни" },
                   new Catalog() { Id = 4, CatalogName = "Цялостна грижа" }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                new Product
                {
                    Id = 1,
                    ProductName = "Крем за лице",
                    Description = "Хидратиращ и успокояващ крем",
                    Picture = "1.jpg",
                    Price = 19.90,
                    CatalogId = 4
                },

                 new Product
                 {
                     Id = 2,
                     ProductName = "Серум за мигли",
                     Description = "Удължава и хидратира миглите",
                     Picture = "0.jpg",
                     Price = 17.99,
                     CatalogId = 2
                 },

				 new Product
				 {
					 Id = 3,
					 ProductName = "Маска за устни",
					 Description = "Облекчава сухите и напукани устни.",
					 Picture = "3.jpg",
					 Price = 21.99,
					 CatalogId = 3
				 }
				) ;
		}

        public DbSet<Product> Products { get; set; }

        public DbSet<Catalog> Catalogs { get; set; }
      
        public DbSet<Review> Reviews { get; set; }
        
        public DbSet<Cart> Carts { get; set; }
        
        public DbSet<Cart_Product> Cart_Products { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
