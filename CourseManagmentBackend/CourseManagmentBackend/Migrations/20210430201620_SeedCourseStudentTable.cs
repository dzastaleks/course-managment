using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class SeedCourseStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CourseStudent",
                columns: new[] { "PkCourseId", "PkStudentID" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 1L, 2L },
                    { 2L, 1L },
                    { 3L, 1L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "PkCourseId", "PkStudentID" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "PkCourseId", "PkStudentID" },
                keyValues: new object[] { 1L, 2L });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "PkCourseId", "PkStudentID" },
                keyValues: new object[] { 2L, 1L });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "PkCourseId", "PkStudentID" },
                keyValues: new object[] { 3L, 1L });
        }
    }
}
