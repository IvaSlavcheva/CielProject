using Ciel.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Ciel.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                //Catalog
                if (!context.Catalogs.Any())
                {
                    context.Catalogs.AddRange(new List<Catalog>()
                            {
                                new Catalog("Цялостна грижа"),
                                new Catalog("Мигли и вежди"),
                                new Catalog( "Околоочна зона"),
                                new Catalog( "Устни"),
                                new Catalog( "Шия")

                            });
                    context.SaveChanges();
                }
                //Product
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                            {
                                new Product("Серум за мигли и вежди Wet n Wild, 5мл",
                                "Струва си да вложите старание в оформянето на миглите си, тъй като те могат перфектно да подчертаят погледа ви. Продуктът Wet n Wild Boost Me Up уверено ще ви помогне в грижата за миглите.",
                                "1.jpg",6.55, context.Catalogs.FirstOrDefault(x => x.CatalogName=="Мигли и вежди"))

                            });
                    context.SaveChanges();

                }


            }
        }
    }


}



