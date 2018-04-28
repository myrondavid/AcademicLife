using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class AddModelsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurricularGrades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsOfficial = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurricularGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    IsRequired = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Workload = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UniversityProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institutes_Universities_UniversityProviderId",
                        column: x => x.UniversityProviderId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    CourseRequiredWorkload = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ElectiveRequiredWorkload = table.Column<int>(nullable: false),
                    FlexibleRequiredWorkload = table.Column<int>(nullable: false),
                    InstituteProviderId = table.Column<int>(nullable: true),
                    MaximumAmountSemesters = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OfficialCurricularGradeId = table.Column<int>(nullable: true),
                    StandardAmountSemesters = table.Column<int>(nullable: false),
                    TccRequiredWorkload = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Institutes_InstituteProviderId",
                        column: x => x.InstituteProviderId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_CurricularGrades_OfficialCurricularGradeId",
                        column: x => x.OfficialCurricularGradeId,
                        principalTable: "CurricularGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassroomId = table.Column<int>(nullable: true),
                    Day = table.Column<int>(nullable: false),
                    FinalTime = table.Column<TimeSpan>(nullable: false),
                    InitialTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DayOfClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfLessons = table.Column<DateTime>(nullable: false),
                    StudentClassroomId = table.Column<int>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    wasPresent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayOfClasses_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    DayOfClassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_DayOfClasses_DayOfClassId",
                        column: x => x.DayOfClassId,
                        principalTable: "DayOfClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: true),
                    CurrentSemesterId = table.Column<int>(nullable: true),
                    StudentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCourses_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CurricularGradeId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsOfficial = table.Column<bool>(nullable: false),
                    SemesterWorkload = table.Column<int>(nullable: false),
                    StudentCourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semesters_CurricularGrades_CurricularGradeId",
                        column: x => x.CurricularGradeId,
                        principalTable: "CurricularGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Semesters_StudentCourses_StudentCourseId",
                        column: x => x.StudentCourseId,
                        principalTable: "StudentCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassLocation = table.Column<string>(nullable: true),
                    ClassSubjectId = table.Column<int>(nullable: true),
                    ClassTeacherId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    InstituteProviderId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsOfficial = table.Column<bool>(nullable: false),
                    SemesterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classrooms_Subjects_ClassSubjectId",
                        column: x => x.ClassSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classrooms_Teachers_ClassTeacherId",
                        column: x => x.ClassTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classrooms_Institutes_InstituteProviderId",
                        column: x => x.InstituteProviderId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classrooms_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassDays_ClassroomId",
                table: "ClassDays",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_ClassSubjectId",
                table: "Classrooms",
                column: "ClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_ClassTeacherId",
                table: "Classrooms",
                column: "ClassTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_InstituteProviderId",
                table: "Classrooms",
                column: "InstituteProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_SemesterId",
                table: "Classrooms",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstituteProviderId",
                table: "Courses",
                column: "InstituteProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OfficialCurricularGradeId",
                table: "Courses",
                column: "OfficialCurricularGradeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DayOfClasses_StudentClassroomId",
                table: "DayOfClasses",
                column: "StudentClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfClasses_StudentId",
                table: "DayOfClasses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutes_UniversityProviderId",
                table: "Institutes",
                column: "UniversityProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_DayOfClassId",
                table: "Lessons",
                column: "DayOfClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_CurricularGradeId",
                table: "Semesters",
                column: "CurricularGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_StudentCourseId",
                table: "Semesters",
                column: "StudentCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CurrentSemesterId",
                table: "StudentCourses",
                column: "CurrentSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassDays_Classrooms_ClassroomId",
                table: "ClassDays",
                column: "ClassroomId",
                principalTable: "Classrooms",
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
                name: "FK_StudentCourses_Semesters_CurrentSemesterId",
                table: "StudentCourses",
                column: "CurrentSemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Institutes_InstituteProviderId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Semesters_CurrentSemesterId",
                table: "StudentCourses");

            migrationBuilder.DropTable(
                name: "ClassDays");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "DayOfClasses");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Institutes");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CurricularGrades");
        }
    }
}
