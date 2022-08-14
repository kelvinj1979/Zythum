using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesSystem.Data.Migrations
{
    public partial class MigrationBrewery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBrewery",
                columns: table => new
                {
                    IdBrewery = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreweryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreweryAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreweryWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBrewery", x => x.IdBrewery);
                });

            migrationBuilder.CreateTable(
                name: "TReports_brewery",
                columns: table => new
                {
                    IdBrewReport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCheckIn = table.Column<int>(type: "int", nullable: false),
                    TotalUser = table.Column<int>(type: "int", nullable: false),
                    TotalLike = table.Column<int>(type: "int", nullable: false),
                    TBrewerysIdBrewery = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TReports_brewery", x => x.IdBrewReport);
                    table.ForeignKey(
                        name: "FK_TReports_brewery_TBrewery_TBrewerysIdBrewery",
                        column: x => x.TBrewerysIdBrewery,
                        principalTable: "TBrewery",
                        principalColumn: "IdBrewery");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TReports_brewery_TBrewerysIdBrewery",
                table: "TReports_brewery",
                column: "TBrewerysIdBrewery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TReports_brewery");

            migrationBuilder.DropTable(
                name: "TBrewery");
        }
    }
}
