using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class ChangeGradeToMark_AddMarkListAtStudentClassroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicActivities_Grades_GradeId",
                table: "AcademicActivities");

            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "AcademicActivities",
                newName: "MarkId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicActivities_GradeId",
                table: "AcademicActivities",
                newName: "IX_AcademicActivities_MarkId");

            migrationBuilder.RenameColumn(
                name: "GradePontuation",
                table: "Grades",
                newName: "MarkPontuation");

            migrationBuilder.AddColumn<int>(
                name: "StudentClassroomId",
                table: "Grades",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentClassroomId",
                table: "Grades",
                column: "StudentClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicActivities_Grades_MarkId",
                table: "AcademicActivities",
                column: "MarkId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_StudentClassrooms_StudentClassroomId",
                table: "Grades",
                column: "StudentClassroomId",
                principalTable: "StudentClassrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicActivities_Grades_MarkId",
                table: "AcademicActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_StudentClassrooms_StudentClassroomId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentClassroomId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "StudentClassroomId",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "MarkId",
                table: "AcademicActivities",
                newName: "GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicActivities_MarkId",
                table: "AcademicActivities",
                newName: "IX_AcademicActivities_GradeId");

            migrationBuilder.RenameColumn(
                name: "MarkPontuation",
                table: "Grades",
                newName: "GradePontuation");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicActivities_Grades_GradeId",
                table: "AcademicActivities",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
