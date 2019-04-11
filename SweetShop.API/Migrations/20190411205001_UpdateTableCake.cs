using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetShop.Api.Migrations
{
    public partial class UpdateTableCake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Cakes",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Status",
                table: "Cakes",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
