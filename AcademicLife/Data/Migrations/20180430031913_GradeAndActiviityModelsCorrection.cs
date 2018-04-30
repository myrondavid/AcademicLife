using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class GradeAndActiviityModelsCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ActivityId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GradePontuation = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicActivities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    GradeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Pontuation = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicActivities_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicActivities_GradeId",
                table: "AcademicActivities",
                column: "GradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicActivities");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
