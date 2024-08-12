using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Migrations
{
    /// <inheritdoc />
    public partial class telegram_buy_invoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plugin",
                table: "Tariffs");

            migrationBuilder.AddColumn<DateTime>(
                name: "date_completed",
                table: "TelegramInvoices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "provider_payment_charge_id",
                table: "TelegramInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telegram_payment_charge_id",
                table: "TelegramInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "total_amount",
                table: "TelegramInvoices",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_completed",
                table: "TelegramInvoices");

            migrationBuilder.DropColumn(
                name: "provider_payment_charge_id",
                table: "TelegramInvoices");

            migrationBuilder.DropColumn(
                name: "telegram_payment_charge_id",
                table: "TelegramInvoices");

            migrationBuilder.DropColumn(
                name: "total_amount",
                table: "TelegramInvoices");

            migrationBuilder.AddColumn<string>(
                name: "Plugin",
                table: "Tariffs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
