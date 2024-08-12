﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class LastFiles_add_DateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "LastFiles",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "LastFiles");
        }
    }
}
