using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDurationDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticeUnits_Units_LessonId",
                table: "PracticeUnits");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "PracticeUnits",
                newName: "UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_PracticeUnits_LessonId",
                table: "PracticeUnits",
                newName: "IX_PracticeUnits_UnitId");

            migrationBuilder.AlterColumn<double>(
                name: "Duration",
                table: "Notes",
                type: "float",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeUnits_Units_UnitId",
                table: "PracticeUnits",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticeUnits_Units_UnitId",
                table: "PracticeUnits");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "PracticeUnits",
                newName: "LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_PracticeUnits_UnitId",
                table: "PracticeUnits",
                newName: "IX_PracticeUnits_LessonId");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Notes",
                type: "time",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeUnits_Units_LessonId",
                table: "PracticeUnits",
                column: "LessonId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
