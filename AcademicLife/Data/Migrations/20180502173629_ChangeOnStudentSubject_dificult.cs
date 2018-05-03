using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class ChangeOnStudentSubject_dificult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dificult",
                table: "StudentSubject");

            migrationBuilder.AddColumn<int>(
                name: "SubjectDifficult",
                table: "StudentSubject",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectDifficult",
                table: "StudentSubject");

            migrationBuilder.AddColumn<int>(
                name: "Dificult",
                table: "StudentSubject",
                nullable: false,
                defaultValue: 0);
        }
    }
}
