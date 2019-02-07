using Microsoft.EntityFrameworkCore.Migrations;

namespace CPAT.Migrations
{
    public partial class changedPreReqInCoursesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_PreRequisites_PreRequisitesId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "PreRequisitesId",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_PreRequisites_PreRequisitesId",
                table: "Courses",
                column: "PreRequisitesId",
                principalTable: "PreRequisites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_PreRequisites_PreRequisitesId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "PreRequisitesId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_PreRequisites_PreRequisitesId",
                table: "Courses",
                column: "PreRequisitesId",
                principalTable: "PreRequisites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
