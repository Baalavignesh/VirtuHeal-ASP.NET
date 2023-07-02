using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtuHeal.Migrations
{
    /// <inheritdoc />
    public partial class VirtuHealauth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PsychiatristpQuestions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    psychiatrist_id = table.Column<int>(type: "int", nullable: false),
                    question1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    answer1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    question2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    answer2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychiatristpQuestions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Psychiatrists",
                columns: table => new
                {
                    psychiatrist_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    college_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychiatrists", x => x.psychiatrist_id);
                });

            migrationBuilder.CreateTable(
                name: "StudentQuestions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    question1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    answer1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    question2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    answer2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    question3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    answer3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    question4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    answer4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuestions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    college_id = table.Column<int>(type: "int", nullable: false),
                    my_psychiatrist = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.student_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PsychiatristpQuestions");

            migrationBuilder.DropTable(
                name: "Psychiatrists");

            migrationBuilder.DropTable(
                name: "StudentQuestions");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
