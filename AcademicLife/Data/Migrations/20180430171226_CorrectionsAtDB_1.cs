using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class CorrectionsAtDB_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Grades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Grades",
                nullable: false,
                defaultValue: 0);
        }
    }
}
