using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Migrations
{
    /// <inheritdoc />
    public partial class try_product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Tariffs_TariffId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TariffId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TariffId1",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "TelegramInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "TariffId",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TariffId",
                table: "Products",
                column: "TariffId");

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

            migrationBuilder.DropIndex(
                name: "IX_Products_TariffId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "TelegramInvoices");

            migrationBuilder.AlterColumn<int>(
                name: "TariffId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "TariffId1",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_TariffId1",
                table: "Products",
                column: "TariffId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Tariffs_TariffId1",
                table: "Products",
                column: "TariffId1",
                principalTable: "Tariffs",
                principalColumn: "Id");
        }
    }
}
