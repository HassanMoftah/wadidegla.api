using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wadidegla.DataLayer.Migrations
{
    public partial class TbCategoryAttributeOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbCategoryAttributeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    CategoryAttributeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCategoryAttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbCategoryAttributeOptions_TbCategoryAttributes_CategoryAttributeId",
                        column: x => x.CategoryAttributeId,
                        principalTable: "TbCategoryAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbCategoryAttributeOptions_CategoryAttributeId",
                table: "TbCategoryAttributeOptions",
                column: "CategoryAttributeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbCategoryAttributeOptions");
        }
    }
}
