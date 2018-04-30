using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class CorrectionsAtDayOfClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassDays_StudentClassrooms_StudentClassroomId",
                table: "ClassDays");

            migrationBuilder.DropForeignKey(
                name: "FK_DayOfClasses_Classrooms_StudentClassroomId",
                table: "DayOfClasses");

            migrationBuilder.DropIndex(
                name: "IX_ClassDays_StudentClassroomId",
                table: "ClassDays");

            migrationBuilder.DropColumn(
                name: "StudentClassroomId",
                table: "ClassDays");

            migrationBuilder.AlterColumn<int>(
                name: "StudentClassroomId",
                table: "DayOfClasses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ClassDayId",
                table: "DayOfClasses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassroomStudentId",
                table: "DayOfClasses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DayOfClasses_ClassDayId",
                table: "DayOfClasses",
                column: "ClassDayId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfClasses_ClassroomStudentId",
                table: "DayOfClasses",
                column: "ClassroomStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfClasses_ClassDays_ClassDayId",
                table: "DayOfClasses",
                column: "ClassDayId",
                principalTable: "ClassDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfClasses_Classrooms_ClassroomStudentId",
                table: "DayOfClasses",
                column: "ClassroomStudentId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfClasses_StudentClassrooms_StudentClassroomId",
                table: "DayOfClasses",
                column: "StudentClassroomId",
                principalTable: "StudentClassrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOfClasses_ClassDays_ClassDayId",
                table: "DayOfClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_DayOfClasses_Classrooms_ClassroomStudentId",
                table: "DayOfClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_DayOfClasses_StudentClassrooms_StudentClassroomId",
                table: "DayOfClasses");

            migrationBuilder.DropIndex(
                name: "IX_DayOfClasses_ClassDayId",
                table: "DayOfClasses");

            migrationBuilder.DropIndex(
                name: "IX_DayOfClasses_ClassroomStudentId",
                table: "DayOfClasses");

            migrationBuilder.DropColumn(
                name: "ClassDayId",
                table: "DayOfClasses");

            migrationBuilder.DropColumn(
                name: "ClassroomStudentId",
                table: "DayOfClasses");

            migrationBuilder.AlterColumn<int>(
                name: "StudentClassroomId",
                table: "DayOfClasses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentClassroomId",
                table: "ClassDays",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassDays_StudentClassroomId",
                table: "ClassDays",
                column: "StudentClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassDays_StudentClassrooms_StudentClassroomId",
                table: "ClassDays",
                column: "StudentClassroomId",
                principalTable: "StudentClassrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfClasses_Classrooms_StudentClassroomId",
                table: "DayOfClasses",
                column: "StudentClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
