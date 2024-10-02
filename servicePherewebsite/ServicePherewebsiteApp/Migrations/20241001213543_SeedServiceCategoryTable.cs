using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServicePherewebsiteApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedServiceCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Service_Categories",
                columns: new[] { "CategoryId", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Services related to personal grooming and beauty, such as hair styling, manicures, pedicures, and makeup services.", "Beauty & Personal Care" },
                    { 2, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Services for electrical installations, repairs, and maintenance, such as fixing electrical faults, installing new wiring, and setting up lighting systems.", "Plumbing" },
                    { 3, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Services related to health and wellness, including personal training, yoga instruction, physiotherapy, nutrition advice, and wellness coaching.", "Health & Fitness" },
                    { 4, new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Includes building, remodeling, and renovation services for homes and commercial properties, covering carpentry, masonry, painting, and flooring.", "Construction & Renovation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Service_Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Service_Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Service_Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Service_Categories",
                keyColumn: "CategoryId",
                keyValue: 4);
        }
    }
}
