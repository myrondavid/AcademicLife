using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class changesAtAcademicActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicActivities_Grades_MarkId",
                table: "AcademicActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_StudentClassrooms_StudentClassroomId",
                table: "Grades");

            migrationBuilder.AlterColumn<int>(
                name: "StudentClassroomId",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MarkId",
                table: "AcademicActivities",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentClassroomId",
                table: "AcademicActivities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicActivities_StudentClassroomId",
                table: "AcademicActivities",
                column: "StudentClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicActivities_Grades_MarkId",
                table: "AcademicActivities",
                column: "MarkId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicActivities_StudentClassrooms_StudentClassroomId",
                table: "AcademicActivities",
                column: "StudentClassroomId",
                principalTable: "StudentClassrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_StudentClassrooms_StudentClassroomId",
                table: "Grades",
                column: "StudentClassroomId",
                principalTable: "StudentClassrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicActivities_Grades_MarkId",
                table: "AcademicActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicActivities_StudentClassrooms_StudentClassroomId",
                table: "AcademicActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_StudentClassrooms_StudentClassroomId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_AcademicActivities_StudentClassroomId",
                table: "AcademicActivities");

            migrationBuilder.DropColumn(
                name: "StudentClassroomId",
                table: "AcademicActivities");

            migrationBuilder.AlterColumn<int>(
                name: "StudentClassroomId",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MarkId",
                table: "AcademicActivities",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
