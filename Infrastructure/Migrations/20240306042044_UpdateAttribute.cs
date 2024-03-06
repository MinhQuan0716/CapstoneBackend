using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Videos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "Videos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Videos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserQuizAttempts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "UserQuizAttempts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "UserQuizAttempts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserProgresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "UserProgresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "UserProgresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "TheoryLessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "TheoryLessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "TheoryLessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Quizzes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "Quizzes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Quizzes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "QuizDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "QuizDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "QuizDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Questions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "Questions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Questions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "QuestionDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "QuestionDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "QuestionDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "PracticeLessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "PracticeLessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "PracticeLessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ListNotes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "ListNotes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ListNotes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ListNoteDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "ListNoteDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ListNoteDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Lessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "Lessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Lessons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Choices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "Choices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Choices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletetionDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserQuizAttempts");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "UserQuizAttempts");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "UserQuizAttempts");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserProgresses");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "UserProgresses");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "UserProgresses");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "TheoryLessons");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "TheoryLessons");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "TheoryLessons");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "QuizDetails");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "QuizDetails");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "QuizDetails");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "QuestionDetails");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "QuestionDetails");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "QuestionDetails");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PracticeLessons");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "PracticeLessons");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "PracticeLessons");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ListNotes");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "ListNotes");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ListNotes");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ListNoteDetails");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "ListNoteDetails");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ListNoteDetails");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DeletetionDate",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Accounts");
        }
    }
}
