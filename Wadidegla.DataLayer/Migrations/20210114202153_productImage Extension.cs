using Microsoft.EntityFrameworkCore.Migrations;

namespace Wadidegla.DataLayer.Migrations
{
    public partial class productImageExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "TbProductImages",
                type: "NVARCHAR(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "TbProductImages");
        }
    }
}
