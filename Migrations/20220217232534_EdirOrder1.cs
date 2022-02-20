using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppForDiplom.Migrations
{
    public partial class EdirOrder1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponceTime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponceTime",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
