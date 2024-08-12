using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Migrations
{
    /// <inheritdoc />
    public partial class changeoperationlogiccomplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OperationCompleted",
                table: "LastFiles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationCompleted",
                table: "LastFiles");
        }
    }
}
