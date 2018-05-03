using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class CorrectionAtAbsence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Classrooms_ClassroomId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Absences_StudentClassrooms_StudentClassroomId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Absences_AspNetUsers_StudentId1",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_ClassroomId",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_StudentId1",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Absences");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Absences",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StudentClassroomId",
                table: "Absences",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Absences_StudentId",
                table: "Absences",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_StudentClassrooms_StudentClassroomId",
                table: "Absences",
                column: "StudentClassroomId",
                principalTable: "StudentClassrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_AspNetUsers_StudentId",
                table: "Absences",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_StudentClassrooms_StudentClassroomId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Absences_AspNetUsers_StudentId",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_StudentId",
                table: "Absences");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Absences",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentClassroomId",
                table: "Absences",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ClassroomId",
                table: "Absences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StudentId1",
                table: "Absences",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Absences_ClassroomId",
                table: "Absences",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_StudentId1",
                table: "Absences",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Classrooms_ClassroomId",
                table: "Absences",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_StudentClassrooms_StudentClassroomId",
                table: "Absences",
                column: "StudentClassroomId",
                principalTable: "StudentClassrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_AspNetUsers_StudentId1",
                table: "Absences",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
