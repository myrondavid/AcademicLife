using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class StudentRegistrationOnStudentCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Registration",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "StudentRegistration",
                table: "StudentCourses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentRegistration",
                table: "StudentCourses");

            migrationBuilder.AddColumn<int>(
                name: "Registration",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
