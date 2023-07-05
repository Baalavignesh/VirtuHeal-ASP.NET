using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtuHeal.Migrations
{
    /// <inheritdoc />
    public partial class new_virtuheal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    college_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    college_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_partner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.college_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_hash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    password_salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    is_online = table.Column<bool>(type: "bit", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
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
                    college_id = table.Column<int>(type: "int", nullable: false),
                    resume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_verified = table.Column<bool>(type: "bit", nullable: false),
                    resume_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychiatrists", x => x.psychiatrist_id);
                    table.ForeignKey(
                        name: "FK_Psychiatrists_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    college_id = table.Column<int>(type: "int", nullable: false),
                    my_psychiatrist = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.student_id);
                    table.ForeignKey(
                        name: "FK_Students_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_PsychiatristpQuestions_Psychiatrists_psychiatrist_id",
                        column: x => x.psychiatrist_id,
                        principalTable: "Psychiatrists",
                        principalColumn: "psychiatrist_id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_StudentQuestions_Students_student_id",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PsychiatristpQuestions_psychiatrist_id",
                table: "PsychiatristpQuestions",
                column: "psychiatrist_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Psychiatrists_user_id",
                table: "Psychiatrists",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestions_student_id",
                table: "StudentQuestions",
                column: "student_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_user_id",
                table: "Students",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colleges");

            migrationBuilder.DropTable(
                name: "PsychiatristpQuestions");

            migrationBuilder.DropTable(
                name: "StudentQuestions");

            migrationBuilder.DropTable(
                name: "Psychiatrists");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
