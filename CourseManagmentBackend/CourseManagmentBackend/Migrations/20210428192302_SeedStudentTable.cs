using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class SeedStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "PkStudentID", "BrojIndeksa", "Ime", "Prezime", "StatusId", "YearId" },
                values: new object[,]
                {
                    { 1L, "123/15", "Marko", "Marković", null, null },
                    { 2L, "124/15", "Petar", "Petrović", null, null },
                    { 4L, "125/15", "Marko", "Petrović", null, null },
                    { 5L, "126/15", "Petar", "Marković", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "PkStudentID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "PkStudentID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "PkStudentID",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "PkStudentID",
                keyValue: 5L);
        }
    }
}
