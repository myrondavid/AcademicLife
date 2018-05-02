using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class CorrectionAtCourse_officialCurricularGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CurricularGrades_CurricularGradeId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CurricularGradeId",
                table: "Courses",
                newName: "OfficialCurricularGradeId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CurricularGradeId",
                table: "Courses",
                newName: "IX_Courses_OfficialCurricularGradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CurricularGrades_OfficialCurricularGradeId",
                table: "Courses",
                column: "OfficialCurricularGradeId",
                principalTable: "CurricularGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CurricularGrades_OfficialCurricularGradeId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "OfficialCurricularGradeId",
                table: "Courses",
                newName: "CurricularGradeId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_OfficialCurricularGradeId",
                table: "Courses",
                newName: "IX_Courses_CurricularGradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CurricularGrades_CurricularGradeId",
                table: "Courses",
                column: "CurricularGradeId",
                principalTable: "CurricularGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
