using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wadidegla.DataLayer.Migrations
{
    public partial class TbProductAndTbProductImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    DefaultProductImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbProducts_TbCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TbCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbProductImages_TbProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TbProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbProductImages_ProductId",
                table: "TbProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProducts_CategoryId",
                table: "TbProducts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbProductImages");

            migrationBuilder.DropTable(
                name: "TbProducts");
        }
    }
}
