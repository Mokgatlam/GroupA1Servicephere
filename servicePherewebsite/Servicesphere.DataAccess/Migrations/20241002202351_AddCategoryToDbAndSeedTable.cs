using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Servicesphere.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToDbAndSeedTable : Migration
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
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Categories", x => x.CategoryId);
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service_Categories");
        }
    }
}
