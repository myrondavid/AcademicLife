using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class CorrectionAtCourse_InstituteProviderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Institutes_InstituteId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "InstituteId",
                table: "Courses",
                newName: "InstituteProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_InstituteId",
                table: "Courses",
                newName: "IX_Courses_InstituteProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Institutes_InstituteProviderId",
                table: "Courses",
                column: "InstituteProviderId",
                principalTable: "Institutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Institutes_InstituteProviderId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "InstituteProviderId",
                table: "Courses",
                newName: "InstituteId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_InstituteProviderId",
                table: "Courses",
                newName: "IX_Courses_InstituteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Institutes_InstituteId",
                table: "Courses",
                column: "InstituteId",
                principalTable: "Institutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
