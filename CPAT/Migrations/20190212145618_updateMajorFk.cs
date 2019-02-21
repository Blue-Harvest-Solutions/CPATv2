using Microsoft.EntityFrameworkCore.Migrations;

namespace CPAT.Migrations
{
    public partial class updateMajorFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MajorRequirements_Students_StudentsId",
                table: "MajorRequirements");

            migrationBuilder.DropIndex(
                name: "IX_MajorRequirements_StudentsId",
                table: "MajorRequirements");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "MajorRequirements");

            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_MajorId",
                table: "Students",
                column: "MajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_MajorRequirements_MajorId",
                table: "Students",
                column: "MajorId",
                principalTable: "MajorRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_MajorRequirements_MajorId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_MajorId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "MajorRequirements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MajorRequirements_StudentsId",
                table: "MajorRequirements",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MajorRequirements_Students_StudentsId",
                table: "MajorRequirements",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
