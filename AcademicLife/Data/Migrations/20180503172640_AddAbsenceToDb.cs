using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class AddAbsenceToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AbsenceId",
                table: "Lessons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AbsenceDate = table.Column<DateTime>(nullable: false),
                    ClassroomId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StudentClassroomId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: false),
                    StudentId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Absences_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Absences_StudentClassrooms_StudentClassroomId",
                        column: x => x.StudentClassroomId,
                        principalTable: "StudentClassrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Absences_AspNetUsers_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_AbsenceId",
                table: "Lessons",
                column: "AbsenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_ClassroomId",
                table: "Absences",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_StudentClassroomId",
                table: "Absences",
                column: "StudentClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_StudentId1",
                table: "Absences",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Absences_AbsenceId",
                table: "Lessons",
                column: "AbsenceId",
                principalTable: "Absences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Absences_AbsenceId",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_AbsenceId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "AbsenceId",
                table: "Lessons");
        }
    }
}
