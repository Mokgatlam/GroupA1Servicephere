using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Servicesphere.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service_Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Service_Products",
                columns: table => new
                {
                    SProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Products", x => x.SProductId);
                    table.ForeignKey(
                        name: "FK_Service_Products_Service_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Service_Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Service_Categories",
                columns: new[] { "CategoryId", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "personal grooming and beauty,hair styling, manicures, pedicures, and makeup services.", "Beauty & Personal Care" },
                    { 2, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Services for electrical installations, repairs, and maintenance, such as fixing electrical faults, installing new wiring, and setting up lighting systems.", "Plumbing" },
                    { 3, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Services related to health and wellness, including personal training, yoga instruction, physiotherapy, nutrition advice, and wellness coaching.", "Health & Fitness" },
                    { 4, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Includes building, remodeling, and renovation services for homes and commercial properties, covering carpentry, masonry, painting, and flooring.", "Construction & Renovation" }
                });

            migrationBuilder.InsertData(
                table: "Service_Products",
                columns: new[] { "SProductId", "CategoryId", "CreatedAt", "Description", "ImageUrls", "IsActive", "IsVerified", "Location", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Professional plaiting services for children, perfect for school and special occasions.", "url1.jpg,url2.jpg,url3.jpg", true, true, "Bloemfontein", "Child Hair Plaiting", 150.0, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Expert electrical repairs and installations.", "electric1.jpg,electric2.jpg", true, false, "Bloemfontein", "Electrical Repairs", 800.0, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Relaxing and rejuvenating facial treatment with natural products.", "facial1.jpg,facial2.jpg", true, false, "Bloemfontein", "Facial Treatment", 450.0, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_Products_CategoryId",
                table: "Service_Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service_Products");

            migrationBuilder.DropTable(
                name: "Service_Categories");
        }
    }
}
