using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ChangeOpinionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Opinions");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Opinions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Opinions");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Opinions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
