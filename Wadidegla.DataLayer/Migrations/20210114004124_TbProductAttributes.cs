using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wadidegla.DataLayer.Migrations
{
    public partial class TbProductAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbProductAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryAttributeId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProductAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbProductAttributes_TbCategoryAttributes_CategoryAttributeId",
                        column: x => x.CategoryAttributeId,
                        principalTable: "TbCategoryAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TbProductAttributes_TbProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TbProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbProductAttributes_CategoryAttributeId",
                table: "TbProductAttributes",
                column: "CategoryAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProductAttributes_ProductId",
                table: "TbProductAttributes",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbProductAttributes");
        }
    }
}
