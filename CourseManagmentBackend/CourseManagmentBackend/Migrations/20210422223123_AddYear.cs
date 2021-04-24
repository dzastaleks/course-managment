using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class AddYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Godina",
                table: "Students");

            migrationBuilder.AddColumn<long>(
                name: "GodinaYearId",
                table: "Students",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    YearId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.YearId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GodinaYearId",
                table: "Students",
                column: "GodinaYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Year_GodinaYearId",
                table: "Students",
                column: "GodinaYearId",
                principalTable: "Year",
                principalColumn: "YearId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Year_GodinaYearId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropIndex(
                name: "IX_Students_GodinaYearId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GodinaYearId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Godina",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
