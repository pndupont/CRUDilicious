using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDILICIOUS.Migrations
{
    public partial class ChangedchefToChef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "chef",
                table: "Dishes",
                newName: "Chef");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Chef",
                table: "Dishes",
                newName: "chef");
        }
    }
}
