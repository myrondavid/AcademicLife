using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class ListOfCoursesInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_AspNetUsers_StudentId",
                table: "StudentCourses");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentCourses",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ApplicationUserId",
                table: "Courses",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_ApplicationUserId",
                table: "Courses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_AspNetUsers_ApplicationUserId",
                table: "StudentCourses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_ApplicationUserId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_AspNetUsers_ApplicationUserId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ApplicationUserId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "StudentCourses",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_ApplicationUserId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_AspNetUsers_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
