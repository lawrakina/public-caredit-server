using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Migrations
{
    /// <inheritdoc />
    public partial class correcttariff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Tariffs_TariffId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_TariffId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TariffId",
                table: "Sales");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Period",
                table: "Tariffs",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tariffs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tariffs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "TariffEndDate",
                table: "Sales",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TariffName",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TariffPrice",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TariffResources",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsersTariffs_TariffId",
                table: "UsersTariffs",
                column: "TariffId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersTariffs_UserId",
                table: "UsersTariffs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersTariffs_Tariffs_TariffId",
                table: "UsersTariffs",
                column: "TariffId",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersTariffs_Users_UserId",
                table: "UsersTariffs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersTariffs_Tariffs_TariffId",
                table: "UsersTariffs");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersTariffs_Users_UserId",
                table: "UsersTariffs");

            migrationBuilder.DropIndex(
                name: "IX_UsersTariffs_TariffId",
                table: "UsersTariffs");

            migrationBuilder.DropIndex(
                name: "IX_UsersTariffs_UserId",
                table: "UsersTariffs");

            migrationBuilder.DropColumn(
                name: "TariffEndDate",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TariffName",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TariffPrice",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TariffResources",
                table: "Sales");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Period",
                table: "Tariffs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tariffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tariffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TariffId",
                table: "Sales",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_TariffId",
                table: "Sales",
                column: "TariffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Tariffs_TariffId",
                table: "Sales",
                column: "TariffId",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
