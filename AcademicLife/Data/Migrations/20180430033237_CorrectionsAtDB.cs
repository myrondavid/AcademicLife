using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class CorrectionsAtDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CourseId",
                table: "AspNetUsers",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Courses_CourseId",
                table: "AspNetUsers",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Courses_CourseId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CourseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "AspNetUsers");
        }
    }
}
