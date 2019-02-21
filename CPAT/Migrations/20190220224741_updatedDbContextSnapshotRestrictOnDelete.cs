using Microsoft.EntityFrameworkCore.Migrations;

namespace CPAT.Migrations
{
    public partial class updatedDbContextSnapshotRestrictOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPlans_Students_StudentId",
                table: "StudentPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_MajorRequirements_MajorId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPlans_Students_StudentId",
                table: "StudentPlans",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_MajorRequirements_MajorId",
                table: "Students",
                column: "MajorId",
                principalTable: "MajorRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPlans_Students_StudentId",
                table: "StudentPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_MajorRequirements_MajorId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPlans_Students_StudentId",
                table: "StudentPlans",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_MajorRequirements_MajorId",
                table: "Students",
                column: "MajorId",
                principalTable: "MajorRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
