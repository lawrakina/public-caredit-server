using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class remove_VipUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plugins_PluginCategory_CategoryId",
                table: "Plugins");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Plugins",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Plugins_PluginCategory_CategoryId",
                table: "Plugins",
                column: "CategoryId",
                principalTable: "PluginCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plugins_PluginCategory_CategoryId",
                table: "Plugins");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Plugins",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plugins_PluginCategory_CategoryId",
                table: "Plugins",
                column: "CategoryId",
                principalTable: "PluginCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
