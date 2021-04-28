using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class ChangeRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_KurseviPkCourseId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentiPkStudentID",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "StudentiPkStudentID",
                table: "CourseStudent",
                newName: "PkStudentID");

            migrationBuilder.RenameColumn(
                name: "KurseviPkCourseId",
                table: "CourseStudent",
                newName: "PkCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_StudentiPkStudentID",
                table: "CourseStudent",
                newName: "IX_CourseStudent_PkStudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_PkCourseId",
                table: "CourseStudent",
                column: "PkCourseId",
                principalTable: "Courses",
                principalColumn: "PkCourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_PkStudentID",
                table: "CourseStudent",
                column: "PkStudentID",
                principalTable: "Students",
                principalColumn: "PkStudentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_PkCourseId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_PkStudentID",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "PkStudentID",
                table: "CourseStudent",
                newName: "StudentiPkStudentID");

            migrationBuilder.RenameColumn(
                name: "PkCourseId",
                table: "CourseStudent",
                newName: "KurseviPkCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_PkStudentID",
                table: "CourseStudent",
                newName: "IX_CourseStudent_StudentiPkStudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_KurseviPkCourseId",
                table: "CourseStudent",
                column: "KurseviPkCourseId",
                principalTable: "Courses",
                principalColumn: "PkCourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentiPkStudentID",
                table: "CourseStudent",
                column: "StudentiPkStudentID",
                principalTable: "Students",
                principalColumn: "PkStudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
