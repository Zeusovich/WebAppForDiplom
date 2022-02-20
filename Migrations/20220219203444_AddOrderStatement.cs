using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppForDiplom.Migrations
{
    public partial class AddOrderStatement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statement",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "OrderStatement",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatement",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Statement",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
