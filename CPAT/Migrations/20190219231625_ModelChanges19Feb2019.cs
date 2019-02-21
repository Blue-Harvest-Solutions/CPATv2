using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPAT.Migrations
{
    public partial class ModelChanges19Feb2019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicTerms_Students_StudentsId",
                table: "AcademicTerms");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_MajorRequirements_MajorRequirementsId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_PreRequisites_PreRequisitesId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "PreRequisites");

            migrationBuilder.DropIndex(
                name: "IX_Courses_MajorRequirementsId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_PreRequisitesId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "MajorRequirementsId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "PreRequisitesId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SeasonAvailability",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "AcademicTerms",
                newName: "StudentPlansId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicTerms_StudentsId",
                table: "AcademicTerms",
                newName: "IX_AcademicTerms_StudentPlansId");

            migrationBuilder.AddColumn<int>(
                name: "StudentPlanId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstSeason",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Year",
                table: "AcademicTerms",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentPlanId",
                table: "Students",
                column: "StudentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_MajorId",
                table: "Courses",
                column: "MajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicTerms_StudentPlans_StudentPlansId",
                table: "AcademicTerms",
                column: "StudentPlansId",
                principalTable: "StudentPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_MajorRequirements_MajorId",
                table: "Courses",
                column: "MajorId",
                principalTable: "MajorRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentPlans_StudentPlanId",
                table: "Students",
                column: "StudentPlanId",
                principalTable: "StudentPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicTerms_StudentPlans_StudentPlansId",
                table: "AcademicTerms");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_MajorRequirements_MajorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentPlans_StudentPlanId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentPlanId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Courses_MajorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentPlanId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EstSeason",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "StudentPlansId",
                table: "AcademicTerms",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicTerms_StudentPlansId",
                table: "AcademicTerms",
                newName: "IX_AcademicTerms_StudentsId");

            migrationBuilder.AddColumn<int>(
                name: "MajorRequirementsId",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreRequisitesId",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeasonAvailability",
                table: "Courses",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "AcademicTerms",
                nullable: false,
                oldClrType: typeof(DateTime));

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
                name: "IX_Courses_MajorRequirementsId",
                table: "Courses",
                column: "MajorRequirementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PreRequisitesId",
                table: "Courses",
                column: "PreRequisitesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicTerms_Students_StudentsId",
                table: "AcademicTerms",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_MajorRequirements_MajorRequirementsId",
                table: "Courses",
                column: "MajorRequirementsId",
                principalTable: "MajorRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_PreRequisites_PreRequisitesId",
                table: "Courses",
                column: "PreRequisitesId",
                principalTable: "PreRequisites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
