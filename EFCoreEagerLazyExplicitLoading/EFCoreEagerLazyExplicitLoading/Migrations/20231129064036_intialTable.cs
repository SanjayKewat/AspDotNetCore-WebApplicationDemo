using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreEagerLazyExplicitLoading.Migrations
{
    public partial class intialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VillaAmenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VillaAmenities_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 1, "Royal Villa", 200.0 });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 2, "Premium Pool Villa", 300.0 });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 3, "Luxuary Pool Villa", 400.0 });

            migrationBuilder.InsertData(
                table: "VillaAmenities",
                columns: new[] { "Id", "Name", "VillaId" },
                values: new object[,]
                {
                    { 1, "Private Villa 1", 1 },
                    { 2, "Private Villa 2", 1 },
                    { 3, "Private Villa 3", 1 },
                    { 4, "Premium Villa 2", 2 },
                    { 5, "Premium Villa 3", 2 },
                    { 6, "Private Luxuary Villa 3", 3 },
                    { 7, "Premium Luxuary Villa 2", 3 },
                    { 8, "Premium Luxuary Villa 3", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VillaAmenities_VillaId",
                table: "VillaAmenities",
                column: "VillaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaAmenities");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
