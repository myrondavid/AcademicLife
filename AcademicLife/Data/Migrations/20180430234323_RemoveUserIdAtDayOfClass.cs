using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class RemoveUserIdAtDayOfClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOfClasses_AspNetUsers_StudentId1",
                table: "DayOfClasses");

            migrationBuilder.DropIndex(
                name: "IX_DayOfClasses_StudentId1",
                table: "DayOfClasses");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "DayOfClasses");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "DayOfClasses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_DayOfClasses_StudentId",
                table: "DayOfClasses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfClasses_AspNetUsers_StudentId",
                table: "DayOfClasses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOfClasses_AspNetUsers_StudentId",
                table: "DayOfClasses");

            migrationBuilder.DropIndex(
                name: "IX_DayOfClasses_StudentId",
                table: "DayOfClasses");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "DayOfClasses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId1",
                table: "DayOfClasses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DayOfClasses_StudentId1",
                table: "DayOfClasses",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfClasses_AspNetUsers_StudentId1",
                table: "DayOfClasses",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
