using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class spGetYearForStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spGetYearForStudent
                                    @id bigint
                                    as 
                                    Begin
                                        Select y.YearId, Naziv From Year y Inner Join Students s on y.YearId = s.YearId Where PkStudentID = @id
                                    End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetYearForStudent";
            migrationBuilder.Sql(procedure);
        }
    }
}
