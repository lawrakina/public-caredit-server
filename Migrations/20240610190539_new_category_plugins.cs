using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class new_category_plugins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Tariffs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PluginCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plugins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plugins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plugins_PluginCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "PluginCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_CategoryId",
                table: "Tariffs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Plugins_CategoryId",
                table: "Plugins",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_PluginCategory_CategoryId",
                table: "Tariffs",
                column: "CategoryId",
                principalTable: "PluginCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tariffs_PluginCategory_CategoryId",
                table: "Tariffs");

            migrationBuilder.DropTable(
                name: "Plugins");

            migrationBuilder.DropTable(
                name: "PluginCategory");

            migrationBuilder.DropIndex(
                name: "IX_Tariffs_CategoryId",
                table: "Tariffs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Tariffs");
        }
    }
}
