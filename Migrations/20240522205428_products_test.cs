using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Migrations
{
    /// <inheritdoc />
    public partial class products_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lots_Tariffs_TariffId",
                table: "Lots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lots",
                table: "Lots");

            migrationBuilder.RenameTable(
                name: "Lots",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Lots_TariffId",
                table: "Products",
                newName: "IX_Products_TariffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Tariffs_TariffId",
                table: "Products",
                column: "TariffId",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Tariffs_TariffId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Lots");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TariffId",
                table: "Lots",
                newName: "IX_Lots_TariffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lots",
                table: "Lots",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_Tariffs_TariffId",
                table: "Lots",
                column: "TariffId",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
