using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fintech.Server.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Securities_Portofolio_PortofolioPortfolioId",
                table: "Securities");

            migrationBuilder.DropTable(
                name: "Portofolio");

            migrationBuilder.DropIndex(
                name: "IX_Securities_PortofolioPortfolioId",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "PortofolioPortfolioId",
                table: "Securities");

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "Securities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Portofolios",
                columns: table => new
                {
                    PortfolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfPortfolio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portofolios", x => x.PortfolioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Securities_PortfolioId",
                table: "Securities",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Securities_Portofolios_PortfolioId",
                table: "Securities",
                column: "PortfolioId",
                principalTable: "Portofolios",
                principalColumn: "PortfolioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Securities_Portofolios_PortfolioId",
                table: "Securities");

            migrationBuilder.DropTable(
                name: "Portofolios");

            migrationBuilder.DropIndex(
                name: "IX_Securities_PortfolioId",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Securities");

            migrationBuilder.AddColumn<int>(
                name: "PortofolioPortfolioId",
                table: "Securities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Portofolio",
                columns: table => new
                {
                    PortfolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOfPortfolio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portofolio", x => x.PortfolioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Securities_PortofolioPortfolioId",
                table: "Securities",
                column: "PortofolioPortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Securities_Portofolio_PortofolioPortfolioId",
                table: "Securities",
                column: "PortofolioPortfolioId",
                principalTable: "Portofolio",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
