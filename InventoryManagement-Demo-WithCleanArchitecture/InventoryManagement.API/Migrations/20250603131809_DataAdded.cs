using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class DataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "InventoryManagement",
                table: "ItemGroup",
                columns: new[] { "Id", "IsVoid", "ItemGroupName" },
                values: new object[,]
                {
                    { 1, false, "Cylindrical Grinding- HMT" },
                    { 2, false, "EDM Machine- GF" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "InventoryManagement",
                table: "ItemGroup",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "InventoryManagement",
                table: "ItemGroup",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
