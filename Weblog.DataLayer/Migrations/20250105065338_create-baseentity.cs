using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weblog.DataLayer.Migrations
{
    public partial class createbaseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Adddate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Adddate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Adddate",
                table: "PostComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "PostComments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Adddate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isdelete",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adddate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Adddate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Adddate",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "Adddate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "isdelete",
                table: "Categories");
        }
    }
}
