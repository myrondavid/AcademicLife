using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AcademicLife.Data.Migrations
{
    public partial class CorrectionAtSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "InstituteProviderId",
                table: "Subjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_InstituteProviderId",
                table: "Subjects",
                column: "InstituteProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Institutes_InstituteProviderId",
                table: "Subjects",
                column: "InstituteProviderId",
                principalTable: "Institutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Institutes_InstituteProviderId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_InstituteProviderId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "InstituteProviderId",
                table: "Subjects");

            migrationBuilder.AddColumn<int>(
                name: "InstituteProviderId1",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstituteProviderIdId",
                table: "Subjects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_InstituteProviderId1",
                table: "Subjects",
                column: "InstituteProviderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_InstituteProviderIdId",
                table: "Subjects",
                column: "InstituteProviderIdId");

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
    }
}
