using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Migrations
{
    /// <inheritdoc />
    public partial class modify_producs_and_add_CategoryItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date_checkout",
                table: "TelegramInvoices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "date_create",
                table: "TelegramInvoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "id_checkout",
                table: "TelegramInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "TelegramInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "TelegramInvoices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Plugin",
                table: "Tariffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plugin",
                table: "LastFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryItems",
                columns: table => new
                {
                    CategoryItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItems", x => x.CategoryItemId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryCategoryItem",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryItemsCategoryItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCategoryItem", x => new { x.CategoriesCategoryId, x.CategoryItemsCategoryItemId });
                    table.ForeignKey(
                        name: "FK_CategoryCategoryItem_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryCategoryItem_CategoryItems_CategoryItemsCategoryItemId",
                        column: x => x.CategoryItemsCategoryItemId,
                        principalTable: "CategoryItems",
                        principalColumn: "CategoryItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCategoryItem_CategoryItemsCategoryItemId",
                table: "CategoryCategoryItem",
                column: "CategoryItemsCategoryItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryCategoryItem");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryItems");

            migrationBuilder.DropColumn(
                name: "date_checkout",
                table: "TelegramInvoices");

            migrationBuilder.DropColumn(
                name: "date_create",
                table: "TelegramInvoices");

            migrationBuilder.DropColumn(
                name: "id_checkout",
                table: "TelegramInvoices");

            migrationBuilder.DropColumn(
                name: "status",
                table: "TelegramInvoices");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "TelegramInvoices");

            migrationBuilder.DropColumn(
                name: "Plugin",
                table: "Tariffs");

            migrationBuilder.DropColumn(
                name: "Plugin",
                table: "LastFiles");
        }
    }
}
