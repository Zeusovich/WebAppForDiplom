using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppForDiplom.Migrations
{
    public partial class AddWorkerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkerName",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkerName",
                table: "Orders");
        }
    }
}
