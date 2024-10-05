using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Servicesphere.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeyForCategoryServiceProductRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Service_Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Name",
                value: "Electrical");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Service_Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Name",
                value: "Plumbing");
        }
    }
}
