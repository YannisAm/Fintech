using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fintech.Server.Migrations
{
    public partial class SecuritySeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
