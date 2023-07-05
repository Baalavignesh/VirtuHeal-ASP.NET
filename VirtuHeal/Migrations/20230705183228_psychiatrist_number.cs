using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtuHeal.Migrations
{
    /// <inheritdoc />
    public partial class psychiatrist_number : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PsychiatristpQuestions_psychiatrist_id",
                table: "PsychiatristpQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "number",
                table: "Psychiatrists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PsychiatristpQuestions_psychiatrist_id",
                table: "PsychiatristpQuestions",
                column: "psychiatrist_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PsychiatristpQuestions_psychiatrist_id",
                table: "PsychiatristpQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "number",
                table: "Psychiatrists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PsychiatristpQuestions_psychiatrist_id",
                table: "PsychiatristpQuestions",
                column: "psychiatrist_id",
                unique: true);
        }
    }
}
