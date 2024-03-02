using Ciel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ciel.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
                    ProductName = "Dior Addict - олио за устни",
                    Description = "В днешно време задължителен за гримьорите, Dior Lip Glow се предлага като блестящо масло за устни, което защитава и подобрява структурата на устните в дълбочина, като трайно подчертава естествения им цвят. С технологията Color Reviver, маслото Lip Glow Oil въздейства директно върху нивото на влага на устните, за да създаде желания цвят, като същевременно осигурява трайна хидратация.",
                    Picture = "image1.jpg",
                    Price = 77.90,
                    CatalogId = 3
                },
                new Product
                {
                    Id = 2,
                    ProductName = "The Ordinary AHA 30% + BHA 2% - пилинг за лице ",
                    Description = "Химическият пилинг The Ordinary AHA 30% + BHA 2% Peeling Solution се грижи за ексфолиране на кожата – повърхностно и в дълбочина. Действа с изключително висока интензивност, но благодарение на добавените хидратиращи съставки и на това, че стойностите на pKa и pH са балансирани, минимизира риска от раздразнение.",
                    Picture = "image2.jpg",
                    Price = 21,
                    CatalogId = 4
                },
                new Product
                {
                    Id = 3,
                    ProductName = "FILORGA OXYGEN-GLOW - околоочен крем",
                    Description = "Кремът за сияен околоочен контур Filorga Oxygen-Glow ще направи погледа ви неустоимо бляскав. Той ще ви отърве от уморените очи, ще изглади фините бръчки и ще озари кожата ви по естествен начин.",
                    Picture = "image3.jpg",
                    Price = 51.40,
                    CatalogId = 1
                },
				new Product
				{
					Id = 4,
					ProductName = "The Ordinary - серум за вежди и мигли ",
					Description = "Серумът The Ordinary Multi-Peptide Lash and Brow Serum ще се погрижи за интензивното подхранване на косъмчетата на веждите и миглите. Подпомага укрепването на отделните косъмчета така, че само след 4 седмици ще забележите видими резултати – увеличен обем, плътност и цялостно по-здрав вид на веждите и миглите.",
					Picture = "image4.jpg",
					Price = 31,
					CatalogId = 2
				},
				new Product
				{
					Id = 5,
					ProductName = "Dior - слънцезащитен крем",
                    Description = "Слънцезащитният крем Dior Solar The Protective Creme SPF 30 защитава лицето от UVA/UVB лъчите. Свежата му текстура моментално се разнася и попива в кожата за приятно усещане. След нанасянето кожата е хидратирана, видимо по-красива и подобрена със сатенен блясък. При продължителна употреба тенът става все по-красив.",
					Picture = "image5.jpg",
					Price = 80.90,
					CatalogId = 4
				},
			    new Product
			    {
					Id = 6,
					ProductName = "FILORGA - околоочен крем",
                    Description = "Осигурете на зоната около очите необходимата грижа, която ще я подсили и подмлади. Мултикоригиращият очен крем Filorga NCEF Reverse Eyes бързо попива в кожата, като освобождава уникалния ревитализиращ NCEF комплекс. Той е съставен от 50 активни вещества в такива високи концентрации, каквито се използват в мезотерапиите.",
					Picture = "image6.jpg",
					Price = 102.40,
					CatalogId = 1
			    },
				new Product
			    {
				     Id = 7,
					 ProductName = "Clarins - блясък за устни",
                     Description = "Подчертайте естествената красота на устните си и оптично им придайте обем в една стъпка. Блясъкът за устни с хидратиращ ефект Clarins Lip Make-Up Instant Light с 3D ефект дарява устните с впечатляваща плътност, оцветява ги леко и същевременно ги подхранва.",
					 Picture = "image7.jpg",
					 Price = 33.99,
					 CatalogId = 3
			    },
				new Product
				{
					Id = 8,
					ProductName = "L’biotica Repair Lash - серум за растеж на мигли",
                    Description = "Изхвърлете изкуствените мигли и заложете на естествената красота. Серумът за растеж на миглите L’biotica ActiveLash ги удължава, подсилва и укрепва само след един месец. Активните съставки стимулират растежа на естествените мигли, предотвратяват падането им и удължават фазата им на растеж.",
					Picture = "image8.jpg",
					Price = 29.10,
					CatalogId = 2
				},

                new Product
                {
                     Id = 9,
                     ProductName = "The Ordinary - озаряващ серум за околоочната зона",
                     Description = "Околоочният серум The Ordinary Multi-Peptide Eye Serum се насочва към най-честите прояви на стареене или умора. В една стъпка ви помага да редуцирате бръчките, отоците, торбичките и тъмните кръгове под очите – успява да направи това благодарение на изключително високата концентрация на активни вещества, включващи цяла серия от патентовани пептидни технологии.",
                     Picture = "image9.jpg",
                     Price = 52,
                     CatalogId = 1
                },
                new Product
                {
                     Id = 10,
                     ProductName = "Makeup Revolution - маска за вежди",
                     Description = "За вашият безупречен външен вид с доказан резултат ще се погрижи тази маска за вежди Make up Revolution Rehab. Тя не съдържа в себе си никакви животински съставки и може да се използва за устни и мигли със същия успех. ",
                     Picture = "image10.jpg",
                     Price = 12.20,
                     CatalogId = 2
                },
                new Product
                {
                     Id = 11,
                     ProductName = "Estée Lauder - изглаждащ серум за устни",
                     Description = "Докато се отдавате на необезпокояван от нищо сън, изглаждащият серум Estée Lauder Pure Color Envy Nighttime Rescue Lip Oil-Serum ще се погрижи за устните ви. Изглажда фините линии и бръчките, успокоява устните и ги оставя здрави, меки и съвършено нежни.",
                     Picture = "image11.jpg",
                     Price = 58.10,
                     CatalogId = 3
                },
                new Product
                {
                      Id = 12,
                      ProductName = "Neutrogena - нощен крем",
                      Description = "Лекият нощен анти-ейдж крем Neutrogena Retinol Boost се абсорбира бързо след нанасяне и освобождава в повърхностните слоеве на кожата чист ретинол.",
                      Picture = "image12.jpg",
                      Price = 58.10,
                      CatalogId = 4
                }
                );
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Catalog> Catalogs { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Cart_Product> Cart_Products { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
