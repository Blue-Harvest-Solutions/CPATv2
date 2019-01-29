using Microsoft.EntityFrameworkCore.Migrations;

namespace CPAT.Migrations
{
    public partial class updatedAcademicTermsAndMajorRequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicTerms_Courses_CourseId",
                table: "AcademicTerms");

            migrationBuilder.DropForeignKey(
                name: "FK_MajorRequirements_Courses_CourseId",
                table: "MajorRequirements");

            migrationBuilder.DropIndex(
                name: "IX_MajorRequirements_CourseId",
                table: "MajorRequirements");

            migrationBuilder.DropIndex(
                name: "IX_AcademicTerms_CourseId",
                table: "AcademicTerms");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "MajorRequirements");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "AcademicTerms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "MajorRequirements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "AcademicTerms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MajorRequirements_CourseId",
                table: "MajorRequirements",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicTerms_CourseId",
                table: "AcademicTerms",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicTerms_Courses_CourseId",
                table: "AcademicTerms",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MajorRequirements_Courses_CourseId",
                table: "MajorRequirements",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
