using Microsoft.EntityFrameworkCore.Migrations;

namespace Acmepay.Infrastructure.Migrations
{
    public partial class init_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CVV",
                table: "CardHolders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV",
                table: "CardHolders");
        }
    }
}
