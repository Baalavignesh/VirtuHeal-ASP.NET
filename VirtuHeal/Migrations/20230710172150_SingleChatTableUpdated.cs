using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtuHeal.Migrations
{
    /// <inheritdoc />
    public partial class SingleChatTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PsychiatristId",
                table: "SingleChatMessage");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "SingleChatMessage");

            migrationBuilder.AddColumn<string>(
                name: "SenderRole",
                table: "SingleChatMessage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderRole",
                table: "SingleChatMessage");

            migrationBuilder.AddColumn<int>(
                name: "PsychiatristId",
                table: "SingleChatMessage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "SingleChatMessage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
