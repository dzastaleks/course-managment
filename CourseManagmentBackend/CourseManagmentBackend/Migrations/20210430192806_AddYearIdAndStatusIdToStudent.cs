using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManagmentBackend.Migrations
{
    public partial class AddYearIdAndStatusIdToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Status_StatusId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Year_YearId",
                table: "Students");

            migrationBuilder.AlterColumn<long>(
                name: "YearId",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StatusId",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Status_StatusId",
                table: "Students",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Year_YearId",
                table: "Students",
                column: "YearId",
                principalTable: "Year",
                principalColumn: "YearId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Status_StatusId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Year_YearId",
                table: "Students");

            migrationBuilder.AlterColumn<long>(
                name: "YearId",
                table: "Students",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "StatusId",
                table: "Students",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Status_StatusId",
                table: "Students",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Year_YearId",
                table: "Students",
                column: "YearId",
                principalTable: "Year",
                principalColumn: "YearId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
