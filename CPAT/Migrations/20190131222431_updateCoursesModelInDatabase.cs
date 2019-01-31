using Microsoft.EntityFrameworkCore.Migrations;

namespace CPAT.Migrations
{
    public partial class updateCoursesModelInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicTermId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeInMajor",
                table: "Courses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MajorRequirementsId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AcademicTermId",
                table: "Courses",
                column: "AcademicTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_MajorRequirementsId",
                table: "Courses",
                column: "MajorRequirementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AcademicTerms_AcademicTermId",
                table: "Courses",
                column: "AcademicTermId",
                principalTable: "AcademicTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_MajorRequirements_MajorRequirementsId",
                table: "Courses",
                column: "MajorRequirementsId",
                principalTable: "MajorRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AcademicTerms_AcademicTermId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_MajorRequirements_MajorRequirementsId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AcademicTermId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_MajorRequirementsId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AcademicTermId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IncludeInMajor",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "MajorRequirementsId",
                table: "Courses");
        }
    }
}
