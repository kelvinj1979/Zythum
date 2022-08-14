using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesSystem.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutYou",
                table: "TUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "TUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "TUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryId",
                table: "TUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenderId",
                table: "TUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutYou",
                table: "TUsers");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "TUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "TUsers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "TUsers");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "TUsers");
        }
    }
}
