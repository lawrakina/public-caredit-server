using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Migrations
{
    /// <inheritdoc />
    public partial class change_data_to_days : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "UserResources");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "UserResources");

            migrationBuilder.AddColumn<double>(
                name: "Days",
                table: "UserResources",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Days",
                table: "UserResources");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "UserResources",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "UserResources",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
