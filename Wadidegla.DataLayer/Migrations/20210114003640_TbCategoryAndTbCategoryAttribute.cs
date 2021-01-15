using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wadidegla.DataLayer.Migrations
{
    public partial class TbCategoryAndTbCategoryAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbCategoryAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCategoryAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbCategoryAttributes_TbCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TbCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbCategoryAttributes_CategoryId",
                table: "TbCategoryAttributes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbCategoryAttributes");

            migrationBuilder.DropTable(
                name: "TbCategories");
        }
    }
}
