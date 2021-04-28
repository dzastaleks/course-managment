using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class spGetStudentDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spGetStudentDetails
                                    @id bigint
                                    as 
                                    Begin
                                        select PkStudentID, Ime, Prezime, BrojIndeksa, StatusId, YearId from Students where PkStudentID = @id;
                                    End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetStudentDetails";
            migrationBuilder.Sql(procedure);
        }
    }
}
