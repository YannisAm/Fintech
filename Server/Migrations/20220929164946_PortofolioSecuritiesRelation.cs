using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fintech.Server.Migrations
{
    public partial class PortofolioSecuritiesRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Securities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Securities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Securities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Securities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                    NameOfPortfolio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Securities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Securities",
                columns: new[] { "Id", "DateTimeObtained", "Description", "Price", "SecurityName", "StockesOwned", "StocksValue" },
                values: new object[] { 1, new DateTime(2022, 9, 21, 19, 48, 55, 263, DateTimeKind.Local).AddTicks(5052), "The best ETF", 152.69f, "VUAA", 3, 458.07f });

            migrationBuilder.InsertData(
                table: "Securities",
                columns: new[] { "Id", "DateTimeObtained", "Description", "Price", "SecurityName", "StockesOwned", "StocksValue" },
                values: new object[] { 2, new DateTime(2022, 9, 21, 19, 48, 55, 263, DateTimeKind.Local).AddTicks(5059), "The best MSFT", 352.42f, "MSFT", 10, 3524.2f });

            migrationBuilder.InsertData(
                table: "Securities",
                columns: new[] { "Id", "DateTimeObtained", "Description", "Price", "SecurityName", "StockesOwned", "StocksValue" },
                values: new object[] { 3, new DateTime(2022, 9, 21, 19, 48, 55, 263, DateTimeKind.Local).AddTicks(5065), "The best technological company", 1253.88f, "APPL", 100, 12538.8f });
        }
    }
}
