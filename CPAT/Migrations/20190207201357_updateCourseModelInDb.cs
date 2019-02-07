using Microsoft.EntityFrameworkCore.Migrations;

namespace CPAT.Migrations
{
    public partial class updateCourseModelInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AcademicTermId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "MajorRequirementsId",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AcademicTermsId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AcademicTermsId",
                table: "Courses",
                column: "AcademicTermsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AcademicTerms_AcademicTermsId",
                table: "Courses",
                column: "AcademicTermsId",
                principalTable: "AcademicTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_MajorRequirements_MajorRequirementsId",
                table: "Courses",
                column: "MajorRequirementsId",
                principalTable: "MajorRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AcademicTerms_AcademicTermsId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_MajorRequirements_MajorRequirementsId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AcademicTermsId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AcademicTermsId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "MajorRequirementsId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AcademicTermId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AcademicTermId",
                table: "Courses",
                column: "AcademicTermId");

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
    }
}
