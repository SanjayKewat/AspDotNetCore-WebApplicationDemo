using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Villas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "IsActive", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fi.guim.co.uk%2Fimg%2Fstatic%2Fsys-images%2FGuardian%2FPix%2Fpictures%2F2014%2F3%2F21%2F1395401774125%2FLorem-ipsum-011.jpg%3Fwidth%3D465%26dpr%3D1%26s%3Dnone&tbnid=vRZtDL4gTwkgMM&vet=12ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw..i&imgrefurl=https%3A%2F%2Fwww.theguardian.com%2Fbooks%2Fbooksblog%2F2014%2Fmar%2F21%2Florem-ipsum-translated-latin-placeholder-text&docid=Q_SoORA3siVI3M&w=460&h=276&q=lorem%20ipsum&ved=2ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw", false, "Pool View", 5, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fi.guim.co.uk%2Fimg%2Fstatic%2Fsys-images%2FGuardian%2FPix%2Fpictures%2F2014%2F3%2F21%2F1395401774125%2FLorem-ipsum-011.jpg%3Fwidth%3D465%26dpr%3D1%26s%3Dnone&tbnid=vRZtDL4gTwkgMM&vet=12ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw..i&imgrefurl=https%3A%2F%2Fwww.theguardian.com%2Fbooks%2Fbooksblog%2F2014%2Fmar%2F21%2Florem-ipsum-translated-latin-placeholder-text&docid=Q_SoORA3siVI3M&w=460&h=276&q=lorem%20ipsum&ved=2ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw", false, "Royal View", 15, 300.0, 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fi.guim.co.uk%2Fimg%2Fstatic%2Fsys-images%2FGuardian%2FPix%2Fpictures%2F2014%2F3%2F21%2F1395401774125%2FLorem-ipsum-011.jpg%3Fwidth%3D465%26dpr%3D1%26s%3Dnone&tbnid=vRZtDL4gTwkgMM&vet=12ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw..i&imgrefurl=https%3A%2F%2Fwww.theguardian.com%2Fbooks%2Fbooksblog%2F2014%2Fmar%2F21%2Florem-ipsum-translated-latin-placeholder-text&docid=Q_SoORA3siVI3M&w=460&h=276&q=lorem%20ipsum&ved=2ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw", false, "Royal View", 15, 21.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fi.guim.co.uk%2Fimg%2Fstatic%2Fsys-images%2FGuardian%2FPix%2Fpictures%2F2014%2F3%2F21%2F1395401774125%2FLorem-ipsum-011.jpg%3Fwidth%3D465%26dpr%3D1%26s%3Dnone&tbnid=vRZtDL4gTwkgMM&vet=12ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw..i&imgrefurl=https%3A%2F%2Fwww.theguardian.com%2Fbooks%2Fbooksblog%2F2014%2Fmar%2F21%2Florem-ipsum-translated-latin-placeholder-text&docid=Q_SoORA3siVI3M&w=460&h=276&q=lorem%20ipsum&ved=2ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw", false, "Royal View", 20, 150.0, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Villas");
        }
    }
}
