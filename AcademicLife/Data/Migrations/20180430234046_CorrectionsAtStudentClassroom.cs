using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class CorrectionsAtStudentClassroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClassrooms_AspNetUsers_StudentId1",
                table: "StudentClassrooms");

            migrationBuilder.DropIndex(
                name: "IX_StudentClassrooms_StudentId1",
                table: "StudentClassrooms");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "StudentClassrooms");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "StudentClassrooms",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassrooms_StudentId",
                table: "StudentClassrooms",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClassrooms_AspNetUsers_StudentId",
                table: "StudentClassrooms",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClassrooms_AspNetUsers_StudentId",
                table: "StudentClassrooms");

            migrationBuilder.DropIndex(
                name: "IX_StudentClassrooms_StudentId",
                table: "StudentClassrooms");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentClassrooms",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId1",
                table: "StudentClassrooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassrooms_StudentId1",
                table: "StudentClassrooms",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClassrooms_AspNetUsers_StudentId1",
                table: "StudentClassrooms",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
