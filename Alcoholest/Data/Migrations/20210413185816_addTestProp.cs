using Microsoft.EntityFrameworkCore.Migrations;

namespace Alcoholest.Data.Migrations
{
    public partial class addTestProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestProp",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestProp",
                table: "Brands");
        }
    }
}
