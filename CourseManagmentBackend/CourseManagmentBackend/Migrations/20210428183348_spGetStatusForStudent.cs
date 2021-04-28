using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class spGetStatusForStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spGetStatusForStudent
                                    @id bigint
                                    as 
                                    Begin
                                       Select st.StatusId, Naziv From Status st Inner Join Students s on st.StatusId = s.StatusId Where PkStudentID = @id
                                    End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetStatusForStudent";
            migrationBuilder.Sql(procedure);
        }
    }
}