using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCompiler.Migrations
{
    public partial class QuestionPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PointsFromQuestions",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PointsFromQuestions",
                table: "Users");
        }
    }
}
