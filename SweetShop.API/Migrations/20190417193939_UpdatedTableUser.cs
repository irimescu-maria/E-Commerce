using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetShop.Api.Migrations
{
    public partial class UpdatedTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LatActive",
                table: "Users",
                newName: "LastActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastActive",
                table: "Users",
                newName: "LatActive");
        }
    }
}
