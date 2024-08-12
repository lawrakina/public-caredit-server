using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class rename_FileName_FileStatistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrigFileName",
                table: "FileStatistics",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrigFileName",
                table: "FileStatistics");
        }
    }
}
