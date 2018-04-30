using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class CorrectionsAtSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutes_Universities_UniversityProviderId",
                table: "Institutes");

            migrationBuilder.AddColumn<int>(
                name: "InstituteProviderId1",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstituteProviderIdId",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UniversityProviderId",
                table: "Institutes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_InstituteProviderId1",
                table: "Subjects",
                column: "InstituteProviderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_InstituteProviderIdId",
                table: "Subjects",
                column: "InstituteProviderIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Institutes_Universities_UniversityProviderId",
                table: "Institutes",
                column: "UniversityProviderId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Institutes_InstituteProviderId1",
                table: "Subjects",
                column: "InstituteProviderId1",
                principalTable: "Institutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Institutes_InstituteProviderIdId",
                table: "Subjects",
                column: "InstituteProviderIdId",
                principalTable: "Institutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutes_Universities_UniversityProviderId",
                table: "Institutes");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Institutes_InstituteProviderId1",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Institutes_InstituteProviderIdId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_InstituteProviderId1",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_InstituteProviderIdId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "InstituteProviderId1",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "InstituteProviderIdId",
                table: "Subjects");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityProviderId",
                table: "Institutes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Institutes_Universities_UniversityProviderId",
                table: "Institutes",
                column: "UniversityProviderId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
