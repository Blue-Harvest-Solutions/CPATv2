using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPAT.Migrations
{
    public partial class updatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "MajorRequirements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreRequisitesId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "AcademicTerms",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PreRequisites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreRequisites", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MajorRequirements_StudentsId",
                table: "MajorRequirements",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PreRequisitesId",
                table: "Courses",
                column: "PreRequisitesId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicTerms_StudentsId",
                table: "AcademicTerms",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicTerms_Students_StudentsId",
                table: "AcademicTerms",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_PreRequisites_PreRequisitesId",
                table: "Courses",
                column: "PreRequisitesId",
                principalTable: "PreRequisites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MajorRequirements_Students_StudentsId",
                table: "MajorRequirements",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicTerms_Students_StudentsId",
                table: "AcademicTerms");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_PreRequisites_PreRequisitesId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_MajorRequirements_Students_StudentsId",
                table: "MajorRequirements");

            migrationBuilder.DropTable(
                name: "PreRequisites");

            migrationBuilder.DropIndex(
                name: "IX_MajorRequirements_StudentsId",
                table: "MajorRequirements");

            migrationBuilder.DropIndex(
                name: "IX_Courses_PreRequisitesId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_AcademicTerms_StudentsId",
                table: "AcademicTerms");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "MajorRequirements");

            migrationBuilder.DropColumn(
                name: "PreRequisitesId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "AcademicTerms");
        }
    }
}
