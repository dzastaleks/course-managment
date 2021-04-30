using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class SeedYearTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Year",
                columns: new[] { "YearId", "Naziv" },
                values: new object[,]
                {
                    { 1L, "Prva" },
                    { 2L, "Druga" },
                    { 3L, "Treća" },
                    { 4L, "Četvrta" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Year",
                keyColumn: "YearId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Year",
                keyColumn: "YearId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Year",
                keyColumn: "YearId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Year",
                keyColumn: "YearId",
                keyValue: 4L);
        }
    }
}
