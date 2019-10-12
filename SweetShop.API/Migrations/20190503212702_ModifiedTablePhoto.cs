using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetShop.Api.Migrations
{
    public partial class ModifiedTablePhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Photos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PublicId",
                table: "Photos",
                newName: "Data");

            migrationBuilder.AddColumn<byte[]>(
                name: "ContentType",
                table: "Photos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Photos",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Photos",
                newName: "PublicId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Photos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Photos",
                nullable: true);
        }
    }
}
