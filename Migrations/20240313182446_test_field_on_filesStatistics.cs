using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoltApi.Migrations
{
    /// <inheritdoc />
    public partial class test_field_on_filesStatistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Test",
                table: "FileStatistics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Test1",
                table: "FileStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "FileStatistics");

            migrationBuilder.DropColumn(
                name: "Test1",
                table: "FileStatistics");
        }
    }
}
