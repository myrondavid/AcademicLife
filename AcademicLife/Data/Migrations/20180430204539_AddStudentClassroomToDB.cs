using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class AddStudentClassroomToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_Subjects_ClassSubjectId",
                table: "Classrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_Teachers_ClassTeacherId",
                table: "Classrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_Institutes_InstituteProviderId",
                table: "Classrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_DayOfClasses_Classrooms_StudentClassroomId",
                table: "DayOfClasses");

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

            migrationBuilder.AlterColumn<int>(
                name: "StudentClassroomId",
                table: "DayOfClasses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId1",
                table: "DayOfClasses",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstituteProviderId",
                table: "Classrooms",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassTeacherId",
                table: "Classrooms",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassSubjectId",
                table: "Classrooms",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentClassroomId",
                table: "ClassDays",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentClassrooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassroomId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    StudentId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentClassrooms_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClassrooms_AspNetUsers_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayOfClasses_StudentId1",
                table: "DayOfClasses",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClassDays_StudentClassroomId",
                table: "ClassDays",
                column: "StudentClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassrooms_ClassroomId",
                table: "StudentClassrooms",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassrooms_StudentId1",
                table: "StudentClassrooms",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassDays_StudentClassrooms_StudentClassroomId",
                table: "ClassDays",
                column: "StudentClassroomId",
                principalTable: "StudentClassrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_Subjects_ClassSubjectId",
                table: "Classrooms",
                column: "ClassSubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_Teachers_ClassTeacherId",
                table: "Classrooms",
                column: "ClassTeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_Institutes_InstituteProviderId",
                table: "Classrooms",
                column: "InstituteProviderId",
                principalTable: "Institutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfClasses_Classrooms_StudentClassroomId",
                table: "DayOfClasses",
                column: "StudentClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfClasses_AspNetUsers_StudentId1",
                table: "DayOfClasses",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassDays_StudentClassrooms_StudentClassroomId",
                table: "ClassDays");

            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_Subjects_ClassSubjectId",
                table: "Classrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_Teachers_ClassTeacherId",
                table: "Classrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_Institutes_InstituteProviderId",
                table: "Classrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_DayOfClasses_Classrooms_StudentClassroomId",
                table: "DayOfClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_DayOfClasses_AspNetUsers_StudentId1",
                table: "DayOfClasses");

            migrationBuilder.DropTable(
                name: "StudentClassrooms");

            migrationBuilder.DropIndex(
                name: "IX_DayOfClasses_StudentId1",
                table: "DayOfClasses");

            migrationBuilder.DropIndex(
                name: "IX_ClassDays_StudentClassroomId",
                table: "ClassDays");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "DayOfClasses");

            migrationBuilder.DropColumn(
                name: "StudentClassroomId",
                table: "ClassDays");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "DayOfClasses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StudentClassroomId",
                table: "DayOfClasses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "InstituteProviderId",
                table: "Classrooms",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClassTeacherId",
                table: "Classrooms",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClassSubjectId",
                table: "Classrooms",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_DayOfClasses_StudentId",
                table: "DayOfClasses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_Subjects_ClassSubjectId",
                table: "Classrooms",
                column: "ClassSubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_Teachers_ClassTeacherId",
                table: "Classrooms",
                column: "ClassTeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_Institutes_InstituteProviderId",
                table: "Classrooms",
                column: "InstituteProviderId",
                principalTable: "Institutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfClasses_Classrooms_StudentClassroomId",
                table: "DayOfClasses",
                column: "StudentClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfClasses_AspNetUsers_StudentId",
                table: "DayOfClasses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
