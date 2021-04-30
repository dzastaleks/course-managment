using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class SeedCoursesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "PkCourseId", "NazivKursa" },
                values: new object[,]
                {
                    { 1L, "Asp.net" },
                    { 2L, "Vuejs" },
                    { 3L, ".Net core" },
                    { 4L, "Python" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "PkCourseId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "PkCourseId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "PkCourseId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "PkCourseId",
                keyValue: 4L);
        }
    }
}
