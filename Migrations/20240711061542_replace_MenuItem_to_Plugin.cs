using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class replace_MenuItem_to_Plugin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Plugins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Plugins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Plugins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plugins_ParentId",
                table: "Plugins",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plugins_Plugins_ParentId",
                table: "Plugins",
                column: "ParentId",
                principalTable: "Plugins",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plugins_Plugins_ParentId",
                table: "Plugins");

            migrationBuilder.DropIndex(
                name: "IX_Plugins_ParentId",
                table: "Plugins");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Plugins");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Plugins");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Plugins");

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuItems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MenuItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_ParentId",
                table: "MenuItems",
                column: "ParentId");
        }
    }
}
