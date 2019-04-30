using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetShop.Api.Migrations
{
    public partial class ChangedTableCake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descrioption",
                table: "Cakes",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Cakes",
                newName: "Descrioption");
        }
    }
}
