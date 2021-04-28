using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class spGetStudentsForCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spGetStudentsForCourse
                                    @id bigint
                                    as 
                                    Begin
                                        select cs.PkStudentID, Ime, Prezime,BrojIndeksa, StatusId, YearId from CourseStudent cs inner Join Students s on cs.PkStudentID = s.PkStudentID Where cs.PkCourseId=@id 
                                    End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetStudentsForCourse";
            migrationBuilder.Sql(procedure);
        }
    
    }
}
