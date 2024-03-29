using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Units_UnitId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.RenameTable(
                name: "Videos",
                newName: "UnitVideos");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_UnitId",
                table: "UnitVideos",
                newName: "IX_UnitVideos_UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitVideos",
                table: "UnitVideos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitVideos_Units_UnitId",
                table: "UnitVideos",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitVideos_Units_UnitId",
                table: "UnitVideos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitVideos",
                table: "UnitVideos");

            migrationBuilder.RenameTable(
                name: "UnitVideos",
                newName: "Videos");

            migrationBuilder.RenameIndex(
                name: "IX_UnitVideos_UnitId",
                table: "Videos",
                newName: "IX_Videos_UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Units_UnitId",
                table: "Videos",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
