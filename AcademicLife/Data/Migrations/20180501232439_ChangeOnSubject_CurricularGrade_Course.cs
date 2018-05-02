using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class ChangeOnSubject_CurricularGrade_Course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Institutes_InstituteProviderId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CurricularGrades_OfficialCurricularGradeId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_CurricularGrades_CurricularGradeId",
                table: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_Semesters_CurricularGradeId",
                table: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_Courses_InstituteProviderId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_OfficialCurricularGradeId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CurricularGradeId",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "InstituteProviderId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "OfficialCurricularGradeId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CurricularGradeId",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SemesterNumber",
                table: "Subjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "CurricularGrades",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurricularGradeId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstituteId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CurricularGradeId",
                table: "Subjects",
                column: "CurricularGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CurricularGradeId",
                table: "Courses",
                column: "CurricularGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstituteId",
                table: "Courses",
                column: "InstituteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CurricularGrades_CurricularGradeId",
                table: "Courses",
                column: "CurricularGradeId",
                principalTable: "CurricularGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Institutes_InstituteId",
                table: "Courses",
                column: "InstituteId",
                principalTable: "Institutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_CurricularGrades_CurricularGradeId",
                table: "Subjects",
                column: "CurricularGradeId",
                principalTable: "CurricularGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CurricularGrades_CurricularGradeId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Institutes_InstituteId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_CurricularGrades_CurricularGradeId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_CurricularGradeId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CurricularGradeId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_InstituteId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CurricularGradeId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SemesterNumber",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "CurricularGrades");

            migrationBuilder.DropColumn(
                name: "CurricularGradeId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CurricularGradeId",
                table: "Semesters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstituteProviderId",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfficialCurricularGradeId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_CurricularGradeId",
                table: "Semesters",
                column: "CurricularGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstituteProviderId",
                table: "Courses",
                column: "InstituteProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OfficialCurricularGradeId",
                table: "Courses",
                column: "OfficialCurricularGradeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Institutes_InstituteProviderId",
                table: "Courses",
                column: "InstituteProviderId",
                principalTable: "Institutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CurricularGrades_OfficialCurricularGradeId",
                table: "Courses",
                column: "OfficialCurricularGradeId",
                principalTable: "CurricularGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_CurricularGrades_CurricularGradeId",
                table: "Semesters",
                column: "CurricularGradeId",
                principalTable: "CurricularGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
