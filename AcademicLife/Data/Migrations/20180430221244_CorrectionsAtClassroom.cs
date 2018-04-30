using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class CorrectionsAtClassroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StudentClassrooms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "StudentClassrooms");
        }
    }
}
