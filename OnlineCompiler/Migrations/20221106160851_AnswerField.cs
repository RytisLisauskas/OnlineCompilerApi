using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCompiler.Migrations
{
    public partial class AnswerField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "AppTasks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "AppTasks");
        }
    }
}
