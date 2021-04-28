using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class spGetCoursesForStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spGetCoursesForStudent
                                    @id bigint
                                    as 
                                    Begin
                                       select cs.PkCourseId, NazivKursa, cs.PkStudentID from CourseStudent cs inner Join Courses c on cs.PkCourseId = c.PkCourseId where PkStudentID=@id
                                    End";
            migrationBuilder.Sql(procedure);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetCoursesForStudent";
            migrationBuilder.Sql(procedure);
        }
    }
}
