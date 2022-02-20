using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppForDiplom.Migrations
{
    public partial class EditOrderValue1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderValue_Orders_OrderId",
                table: "OrderValue");

            migrationBuilder.DropIndex(
                name: "IX_OrderValue_OrderId",
                table: "OrderValue");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderValue");

            migrationBuilder.AddColumn<int>(
                name: "OrderValueId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderValueId",
                table: "Orders",
                column: "OrderValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderValue_OrderValueId",
                table: "Orders",
                column: "OrderValueId",
                principalTable: "OrderValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderValue_OrderValueId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderValueId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderValueId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderValue",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderValue_OrderId",
                table: "OrderValue",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderValue_Orders_OrderId",
                table: "OrderValue",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
