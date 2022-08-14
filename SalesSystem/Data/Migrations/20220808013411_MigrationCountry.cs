using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesSystem.Data.Migrations
{
    public partial class MigrationCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CountryId",
                table: "TUsers",
                type: "nvarchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NamePT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCode = table.Column<int>(type: "int", nullable: false),
                    Iso3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TUsers_CountryId",
                table: "TUsers",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TUsers_Countries_CountryId",
                table: "TUsers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TUsers_Countries_CountryId",
                table: "TUsers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_TUsers_CountryId",
                table: "TUsers");

            migrationBuilder.AlterColumn<string>(
                name: "CountryId",
                table: "TUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldNullable: true);
        }
    }
}
