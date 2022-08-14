using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesSystem.Data.Migrations
{
    public partial class MigrationBeer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBeers",
                columns: table => new
                {
                    BeerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeerStyle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeerABV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeerIBU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BreweryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBeers", x => x.BeerId);
                });

            migrationBuilder.CreateTable(
                name: "TReports_beer",
                columns: table => new
                {
                    IdBeerReport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCheckIn = table.Column<int>(type: "int", nullable: false),
                    TotalRating = table.Column<int>(type: "int", nullable: false),
                    TotalLike = table.Column<int>(type: "int", nullable: false),
                    TBeersBeerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TReports_beer", x => x.IdBeerReport);
                    table.ForeignKey(
                        name: "FK_TReports_beer_TBeers_TBeersBeerId",
                        column: x => x.TBeersBeerId,
                        principalTable: "TBeers",
                        principalColumn: "BeerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TReports_beer_TBeersBeerId",
                table: "TReports_beer",
                column: "TBeersBeerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TReports_beer");

            migrationBuilder.DropTable(
                name: "TBeers");
        }
    }
}
