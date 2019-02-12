using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPAT.Migrations
{
    public partial class addStudentPlanViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentPlanViewModelId",
                table: "MajorRequirements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentPlanViewModelId",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentPlanViewModelId",
                table: "AcademicTerms",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentPlanViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPlanViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentPlanViewModel_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MajorRequirements_StudentPlanViewModelId",
                table: "MajorRequirements",
                column: "StudentPlanViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentPlanViewModelId",
                table: "Courses",
                column: "StudentPlanViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicTerms_StudentPlanViewModelId",
                table: "AcademicTerms",
                column: "StudentPlanViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPlanViewModel_StudentId",
                table: "StudentPlanViewModel",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicTerms_StudentPlanViewModel_StudentPlanViewModelId",
                table: "AcademicTerms",
                column: "StudentPlanViewModelId",
                principalTable: "StudentPlanViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_StudentPlanViewModel_StudentPlanViewModelId",
                table: "Courses",
                column: "StudentPlanViewModelId",
                principalTable: "StudentPlanViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MajorRequirements_StudentPlanViewModel_StudentPlanViewModelId",
                table: "MajorRequirements",
                column: "StudentPlanViewModelId",
                principalTable: "StudentPlanViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicTerms_StudentPlanViewModel_StudentPlanViewModelId",
                table: "AcademicTerms");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_StudentPlanViewModel_StudentPlanViewModelId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_MajorRequirements_StudentPlanViewModel_StudentPlanViewModelId",
                table: "MajorRequirements");

            migrationBuilder.DropTable(
                name: "StudentPlanViewModel");

            migrationBuilder.DropIndex(
                name: "IX_MajorRequirements_StudentPlanViewModelId",
                table: "MajorRequirements");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentPlanViewModelId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_AcademicTerms_StudentPlanViewModelId",
                table: "AcademicTerms");

            migrationBuilder.DropColumn(
                name: "StudentPlanViewModelId",
                table: "MajorRequirements");

            migrationBuilder.DropColumn(
                name: "StudentPlanViewModelId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentPlanViewModelId",
                table: "AcademicTerms");
        }
    }
}
