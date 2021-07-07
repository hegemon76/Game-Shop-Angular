using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class OpinionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Opinions",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Opinions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Opinions");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Opinions",
                newName: "UserName");
        }
    }
}
