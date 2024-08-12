using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_visibility_on_keySaleTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "KeySaleTemplates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visible",
                table: "KeySaleTemplates");
        }
    }
}
