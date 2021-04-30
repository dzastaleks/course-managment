using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class SeedStudentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "PkStudentID", "BrojIndeksa", "Ime", "Prezime", "StatusId", "YearId" },
                values: new object[,]
                {
                    { 1L, "123/15", "Marko", "Marković", 1L, 1L },
                    { 2L, "124/15", "Petar", "Petrović", 2L, 2L },
                    { 4L, "125/15", "Marko", "Petrović", 1L, 1L },
                    { 5L, "126/15", "Petar", "Marković", 1L, 1L }
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
