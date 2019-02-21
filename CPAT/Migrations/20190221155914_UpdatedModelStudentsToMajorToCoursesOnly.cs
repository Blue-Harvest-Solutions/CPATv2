using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPAT.Migrations
{
    public partial class UpdatedModelStudentsToMajorToCoursesOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicTerms_StudentPlanViewModel_StudentPlanViewModelId",
                table: "AcademicTerms");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_MajorRequirements_MajorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_StudentPlanViewModel_StudentPlanViewModelId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_MajorRequirements_StudentPlanViewModel_StudentPlanViewModelId",
                table: "MajorRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPlans_MajorRequirements_MajorId",
                table: "StudentPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_MajorRequirements_MajorId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "StudentPlanViewModel");

            migrationBuilder.DropIndex(
                name: "IX_StudentPlans_MajorId",
                table: "StudentPlans");

            migrationBuilder.DropIndex(
                name: "IX_MajorRequirements_StudentPlanViewModelId",
                table: "MajorRequirements");

            migrationBuilder.DropIndex(
                name: "IX_Courses_MajorId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_AcademicTerms_StudentPlanViewModelId",
                table: "AcademicTerms");

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "StudentPlans");

            migrationBuilder.DropColumn(
                name: "StudentPlanViewModelId",
                table: "MajorRequirements");

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentPlanViewModelId",
                table: "AcademicTerms");

            migrationBuilder.RenameColumn(
                name: "StudentPlanViewModelId",
                table: "Courses",
                newName: "MajorRequirementsId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_StudentPlanViewModelId",
                table: "Courses",
                newName: "IX_Courses_MajorRequirementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_MajorRequirements_MajorRequirementsId",
                table: "Courses",
                column: "MajorRequirementsId",
                principalTable: "MajorRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

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
                name: "FK_Courses_MajorRequirements_MajorRequirementsId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_MajorRequirements_MajorId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "MajorRequirementsId",
                table: "Courses",
                newName: "StudentPlanViewModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_MajorRequirementsId",
                table: "Courses",
                newName: "IX_Courses_StudentPlanViewModelId");

            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "StudentPlans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentPlanViewModelId",
                table: "MajorRequirements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentPlans_MajorId",
                table: "StudentPlans",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_MajorRequirements_StudentPlanViewModelId",
                table: "MajorRequirements",
                column: "StudentPlanViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_MajorId",
                table: "Courses",
                column: "MajorId");

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_MajorRequirements_MajorId",
                table: "Courses",
                column: "MajorId",
                principalTable: "MajorRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_StudentPlanViewModel_StudentPlanViewModelId",
                table: "Courses",
                column: "StudentPlanViewModelId",
                principalTable: "StudentPlanViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MajorRequirements_StudentPlanViewModel_StudentPlanViewModelId",
                table: "MajorRequirements",
                column: "StudentPlanViewModelId",
                principalTable: "StudentPlanViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPlans_MajorRequirements_MajorId",
                table: "StudentPlans",
                column: "MajorId",
                principalTable: "MajorRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

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
