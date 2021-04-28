using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class spGetCourseDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spGetCourseDetails
                                    @id bigint
                                    as 
                                    Begin
                                        select PkCourseId, NazivKursa from Courses Where PkCourseId = @id
                                    End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetCourseDetails";
            migrationBuilder.Sql(procedure);

        }
    }
}
