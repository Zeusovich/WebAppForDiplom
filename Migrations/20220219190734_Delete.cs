using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppForDiplom.Migrations
{
    public partial class Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderValue_OrderValueId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderValue");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderValueId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderValueId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Feedback",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Recommend",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValueBeginOfWork",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValueEndOfWork",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Recommend",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ValueBeginOfWork",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ValueEndOfWork",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderValueId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feedback = table.Column<int>(type: "int", nullable: false),
                    Recommend = table.Column<int>(type: "int", nullable: false),
                    ValueBeginOfWork = table.Column<int>(type: "int", nullable: false),
                    ValueEndOfWork = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderValue", x => x.Id);
                });

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
    }
}
