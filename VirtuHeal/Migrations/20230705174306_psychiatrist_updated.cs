using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtuHeal.Migrations
{
    /// <inheritdoc />
    public partial class psychiatrist_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentQuestions_student_id",
                table: "StudentQuestions");

            migrationBuilder.DropColumn(
                name: "experience",
                table: "Psychiatrists");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Psychiatrists",
                newName: "gender");

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "Psychiatrists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestions_student_id",
                table: "StudentQuestions",
                column: "student_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentQuestions_student_id",
                table: "StudentQuestions");

            migrationBuilder.DropColumn(
                name: "age",
                table: "Psychiatrists");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Psychiatrists",
                newName: "location");

            migrationBuilder.AddColumn<string>(
                name: "experience",
                table: "Psychiatrists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestions_student_id",
                table: "StudentQuestions",
                column: "student_id",
                unique: true);
        }
    }
}
