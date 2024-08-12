using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Migrations
{
    /// <inheritdoc />
    public partial class add_tariff_to_product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TariffId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Tariffs_TariffId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TariffId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TariffId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TariffId1",
                table: "Products");
        }
    }
}
