using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fintech.Server.Migrations
{
    public partial class changedtheformat4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PortofolioId",
                table: "Securities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PortofolioId",
                table: "Securities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
