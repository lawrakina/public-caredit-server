using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class remove_old_classes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileType",
                table: "FileStatistics");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Files");

            migrationBuilder.AddColumn<string>(
                name: "OrigFileName",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrigPath",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrigFileName",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "OrigPath",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "FileStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "Files",
                type: "int",
                nullable: true);
        }
    }
}
