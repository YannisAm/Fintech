using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fintech.Server.Migrations
{
    public partial class correct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Securities_Portofolios_PortfolioId",
                table: "Securities");

            migrationBuilder.AlterColumn<int>(
                name: "PortfolioId",
                table: "Securities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Securities_Portofolios_PortfolioId",
                table: "Securities",
                column: "PortfolioId",
                principalTable: "Portofolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Securities_Portofolios_PortfolioId",
                table: "Securities");

            migrationBuilder.AlterColumn<int>(
                name: "PortfolioId",
                table: "Securities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Securities_Portofolios_PortfolioId",
                table: "Securities",
                column: "PortfolioId",
                principalTable: "Portofolios",
                principalColumn: "PortfolioId");
        }
    }
}
