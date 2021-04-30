using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class SeedStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "Naziv" },
                values: new object[] { 1L, "Redovan" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "Naziv" },
                values: new object[] { 2L, "Vanredni" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 2L);
        }
    }
}
