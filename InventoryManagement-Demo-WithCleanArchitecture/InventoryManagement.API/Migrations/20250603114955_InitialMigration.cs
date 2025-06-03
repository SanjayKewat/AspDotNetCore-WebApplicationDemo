using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "InventoryManagement");

            migrationBuilder.CreateTable(
                name: "ItemGroup",
                schema: "InventoryManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemGroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsVoid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentInventory",
                schema: "InventoryManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrackingMethod = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ItemGroupId = table.Column<int>(type: "int", nullable: false),
                    IsVoid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentInventory_ItemGroup_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalSchema: "InventoryManagement",
                        principalTable: "ItemGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentInventory_ItemGroupId",
                schema: "InventoryManagement",
                table: "EquipmentInventory",
                column: "ItemGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentInventory",
                schema: "InventoryManagement");

            migrationBuilder.DropTable(
                name: "ItemGroup",
                schema: "InventoryManagement");
        }
    }
}
