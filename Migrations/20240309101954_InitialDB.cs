using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ciel.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EGN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CatalogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Catalogs_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart_Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Products_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Products_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Catalogs",
                columns: new[] { "Id", "CatalogName" },
                values: new object[,]
                {
                    { 1, "Околоочна зона" },
                    { 2, "Вежди и мигли" },
                    { 3, "Устни" },
                    { 4, "Цялостна грижа" },
                    { 5, "Аксесоари" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CatalogId", "Description", "Picture", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, 3, "В днешно време задължителен за гримьорите, Dior Lip Glow се предлага като блестящо масло за устни, което защитава и подобрява структурата на устните в дълбочина, като трайно подчертава естествения им цвят. С технологията Color Reviver, маслото Lip Glow Oil въздейства директно върху нивото на влага на устните, за да създаде желания цвят, като същевременно осигурява трайна хидратация.", "image1.jpg", 77.900000000000006, "Dior Addict - олио за устни" },
                    { 2, 4, "Химическият пилинг The Ordinary AHA 30% + BHA 2% Peeling Solution се грижи за ексфолиране на кожата – повърхностно и в дълбочина. Действа с изключително висока интензивност, но благодарение на добавените хидратиращи съставки и на това, че стойностите на pKa и pH са балансирани, минимизира риска от раздразнение.", "image2.jpg", 21.0, "The Ordinary AHA 30% + BHA 2% - пилинг за лице " },
                    { 3, 1, "Кремът за сияен околоочен контур Filorga Oxygen-Glow ще направи погледа ви неустоимо бляскав. Той ще ви отърве от уморените очи, ще изглади фините бръчки и ще озари кожата ви по естествен начин.", "image3.jpg", 51.399999999999999, "FILORGA OXYGEN-GLOW - околоочен крем" },
                    { 4, 2, "Серумът The Ordinary Multi-Peptide Lash and Brow Serum ще се погрижи за интензивното подхранване на косъмчетата на веждите и миглите. Подпомага укрепването на отделните косъмчета така, че само след 4 седмици ще забележите видими резултати – увеличен обем, плътност и цялостно по-здрав вид на веждите и миглите.", "image4.jpg", 31.0, "The Ordinary - серум за вежди и мигли " },
                    { 5, 4, "Слънцезащитният крем Dior Solar The Protective Creme SPF 30 защитава лицето от UVA/UVB лъчите. Свежата му текстура моментално се разнася и попива в кожата за приятно усещане. След нанасянето кожата е хидратирана, видимо по-красива и подобрена със сатенен блясък. При продължителна употреба тенът става все по-красив.", "image5.jpg", 80.900000000000006, "Dior - слънцезащитен крем" },
                    { 6, 1, "Осигурете на зоната около очите необходимата грижа, която ще я подсили и подмлади. Мултикоригиращият очен крем Filorga NCEF Reverse Eyes бързо попива в кожата, като освобождава уникалния ревитализиращ NCEF комплекс. Той е съставен от 50 активни вещества в такива високи концентрации, каквито се използват в мезотерапиите.", "image6.jpg", 102.40000000000001, "FILORGA - околоочен крем" },
                    { 7, 3, "Подчертайте естествената красота на устните си и оптично им придайте обем в една стъпка. Блясъкът за устни с хидратиращ ефект Clarins Lip Make-Up Instant Light с 3D ефект дарява устните с впечатляваща плътност, оцветява ги леко и същевременно ги подхранва.", "image7.jpg", 33.990000000000002, "Clarins - блясък за устни" },
                    { 8, 2, "Изхвърлете изкуствените мигли и заложете на естествената красота. Серумът за растеж на миглите L’biotica ActiveLash ги удължава, подсилва и укрепва само след един месец. Активните съставки стимулират растежа на естествените мигли, предотвратяват падането им и удължават фазата им на растеж.", "image8.jpg", 29.100000000000001, "L’biotica Repair Lash - серум за растеж на мигли" },
                    { 9, 1, "Околоочният серум The Ordinary Multi-Peptide Eye Serum се насочва към най-честите прояви на стареене или умора. В една стъпка ви помага да редуцирате бръчките, отоците, торбичките и тъмните кръгове под очите – успява да направи това благодарение на изключително високата концентрация на активни вещества, включващи цяла серия от патентовани пептидни технологии.", "image9.jpg", 52.0, "The Ordinary - озаряващ серум за околоочната зона" },
                    { 10, 2, "За вашият безупречен външен вид с доказан резултат ще се погрижи тази маска за вежди Make up Revolution Rehab. Тя не съдържа в себе си никакви животински съставки и може да се използва за устни и мигли със същия успех. ", "image10.jpg", 12.199999999999999, "Makeup Revolution - маска за вежди" },
                    { 11, 3, "Докато се отдавате на необезпокояван от нищо сън, изглаждащият серум Estée Lauder Pure Color Envy Nighttime Rescue Lip Oil-Serum ще се погрижи за устните ви. Изглажда фините линии и бръчките, успокоява устните и ги оставя здрави, меки и съвършено нежни.", "image11.jpg", 58.100000000000001, "Estée Lauder - изглаждащ серум за устни" },
                    { 12, 4, "Лекият нощен анти-ейдж крем Neutrogena Retinol Boost се абсорбира бързо след нанасяне и освобождава в повърхностните слоеве на кожата чист ретинол.", "image12.jpg", 58.100000000000001, "Neutrogena - нощен крем" },
                    { 13, 1, "Възвърнете младежкия вид на очите си. Опитайте възстановяващата сила на екстракта от рози Grand Rose, култовата съставка на марката Lancôme. Ревитализиращият очен серум Lancôme Absolue видимо изглажда, омекотява и стяга контурите на очите и гарантира по-сияйна околоочна зона без бръчки.", "image13.jpg", 270.0, "Lancôme - серум за очи" },
                    { 14, 2, "Продуктът Beauty Jar Second Chance подчертава вашия поглед и изтъква красотата на очите ви.", "image14.png", 10.9, "Beauty Jar - подхранващо масло за вежди" },
                    { 15, 3, "Завидна усмивка с меки и чувствени устни. Възобновяващият балсам за устни Estée Lauder Pure Color Envy Lip Repair Potion омекотява и изглажда устните, като същевременно дефинира външния им вид. Богат на масла, балсамът действа като регенерираща терапия през нощта и предава на устните страхотен вид. Благодарение на апликатора-пръчка, балсамът се нанася лесно и бързо, дори и в най-забързаните моменти.", "image15.jpg", 69.5, "Estée Lauder - възстановяващ балсам за устни" },
                    { 16, 4, "Имате ли усещането, че в момента кожата на лицето ви не е в оптимална кондиция и ви трябва нещо повече, освен грижата, предлагана от крема? Маската за лице Symbiosis London Age Illuminating Cannabidiol обогатява чудесно ежедневната ви рутина – глези кожата и ѝ осигурява интензивна грижа, която носи незабавно подобряване на външния ѝ вид.", "image16.jpg", 76.200000000000003, "Symbiosis London - маска за лице" },
                    { 17, 5, "Масажорът е изработен от розов кварц от Южна Африка и разполага с бамбукова дръжка и две различни по големина ролки в двата си края. По-малката е подходяща за по-деликатните зони на лицето, а по-голямата е чудесна за масаж на по-големи зони от кожата.", "image17.jpg", 27.899999999999999, "Масажор за лице" },
                    { 18, 5, "Малка ексфолираща гъба, която в комбинация с любим измиващ продукт ще почисти ефективно кожата на лицето Ви. Изработена е с фина плетка, която осигурява ексфолиращия ефект и премахва мъртвите клетки, разкривайки по-меката и сияйна кожа на лицето.", "image18.jpg", 9.8000000000000007, "Гъба за почистване на лице" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Products_CartId",
                table: "Cart_Products",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Products_ProductId",
                table: "Cart_Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                table: "Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatalogId",
                table: "Products",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cart_Products");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Catalogs");
        }
    }
}
