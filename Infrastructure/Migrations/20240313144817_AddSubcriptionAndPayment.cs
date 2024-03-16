using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSubcriptionAndPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuizAttempts",
                table: "UserQuizAttempts");

            migrationBuilder.DropIndex(
                name: "IX_UserQuizAttempts_QuizId",
                table: "UserQuizAttempts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProgresses",
                table: "UserProgresses");

            migrationBuilder.DropIndex(
                name: "IX_UserProgresses_CourseId",
                table: "UserProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListNoteDetails",
                table: "ListNoteDetails");

            migrationBuilder.DropIndex(
                name: "IX_ListNoteDetails_ListNoteId",
                table: "ListNoteDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserQuizAttempts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserProgresses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ListNoteDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuizAttempts",
                table: "UserQuizAttempts",
                columns: new[] { "QuizId", "AccountId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProgresses",
                table: "UserProgresses",
                columns: new[] { "CourseId", "AccountId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListNoteDetails",
                table: "ListNoteDetails",
                columns: new[] { "ListNoteId", "NoteId" });

            migrationBuilder.CreateTable(
                name: "Subcription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubcriptionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubcriptionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Feature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingCycle = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletetionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcription", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    SubcriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletetionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => new { x.AccountId, x.SubcriptionId });
                    table.ForeignKey(
                        name: "FK_Payment_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Subcription_SubcriptionId",
                        column: x => x.SubcriptionId,
                        principalTable: "Subcription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_SubcriptionId",
                table: "Payment",
                column: "SubcriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Subcription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuizAttempts",
                table: "UserQuizAttempts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProgresses",
                table: "UserProgresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListNoteDetails",
                table: "ListNoteDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserQuizAttempts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserProgresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ListNoteDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuizAttempts",
                table: "UserQuizAttempts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProgresses",
                table: "UserProgresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListNoteDetails",
                table: "ListNoteDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuizAttempts_QuizId",
                table: "UserQuizAttempts",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgresses_CourseId",
                table: "UserProgresses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ListNoteDetails_ListNoteId",
                table: "ListNoteDetails",
                column: "ListNoteId");
        }
    }
}
