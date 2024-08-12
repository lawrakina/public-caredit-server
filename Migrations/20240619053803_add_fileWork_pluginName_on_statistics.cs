using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_fileWork_pluginName_on_statistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PluginName",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PluginName",
                table: "Files");
        }
    }
}
