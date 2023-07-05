using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtuHeal.Migrations
{
    /// <inheritdoc />
    public partial class psychiatrist_resume_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "resume",
                table: "Psychiatrists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "resume",
                table: "Psychiatrists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
