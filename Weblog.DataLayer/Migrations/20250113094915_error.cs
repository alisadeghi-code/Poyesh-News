using Microsoft.EntityFrameworkCore.Migrations;

namespace Weblog.DataLayer.Migrations
{
    public partial class error : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isdelete",
                table: "Users",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "Adddate",
                table: "Users",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "isdelete",
                table: "Posts",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "Adddate",
                table: "Posts",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "isdelete",
                table: "PostComments",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "Adddate",
                table: "PostComments",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "isdelete",
                table: "Categories",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "Adddate",
                table: "Categories",
                newName: "CreationDate");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Visit",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Visit",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Users",
                newName: "isdelete");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Users",
                newName: "Adddate");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Posts",
                newName: "isdelete");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Posts",
                newName: "Adddate");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "PostComments",
                newName: "isdelete");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "PostComments",
                newName: "Adddate");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Categories",
                newName: "isdelete");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Categories",
                newName: "Adddate");
        }
    }
}
