using Microsoft.EntityFrameworkCore.Migrations;

namespace Weblog.DataLayer.Migrations
{
    public partial class questions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discussion",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interest",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsType",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sources",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discussion",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Interest",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NewsType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Sources",
                table: "Users");
        }
    }
}
