using Microsoft.EntityFrameworkCore.Migrations;

namespace CPAT.Migrations
{
    public partial class UpdatedStudentsMajorIdOnDeleteRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_MajorRequirements_MajorId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_MajorRequirements_MajorId",
                table: "Students",
                column: "MajorId",
                principalTable: "MajorRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_MajorRequirements_MajorId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_MajorRequirements_MajorId",
                table: "Students",
                column: "MajorId",
                principalTable: "MajorRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
