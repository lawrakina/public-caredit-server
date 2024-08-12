using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class remove_old_prices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tariffs");

            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "KeySaleTemplates");

            migrationBuilder.RenameColumn(
                name: "RecommendedPrice",
                table: "KeySaleTemplates",
                newName: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "TariffPrice",
                table: "Sales",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "KeySaleTemplates",
                newName: "RecommendedPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Tariffs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "TariffPrice",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BasePrice",
                table: "KeySaleTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
