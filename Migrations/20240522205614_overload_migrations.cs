using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Migrations
{
    /// <inheritdoc />
    public partial class overload_migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Tariffs_TariffId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products_test");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TariffId",
                table: "Products_test",
                newName: "IX_Products_test_TariffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products_test",
                table: "Products_test",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_test_Tariffs_TariffId",
                table: "Products_test",
                column: "TariffId",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_test_Tariffs_TariffId",
                table: "Products_test");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products_test",
                table: "Products_test");

            migrationBuilder.RenameTable(
                name: "Products_test",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Products_test_TariffId",
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
    }
}
