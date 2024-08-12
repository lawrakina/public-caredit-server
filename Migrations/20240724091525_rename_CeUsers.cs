using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Migrations
{
    /// <inheritdoc />
    public partial class rename_CeUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_UserId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_FileStatistics_Users_UserId",
                table: "FileStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_KeySaleInvoices_Users_UserId",
                table: "KeySaleInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_KeySales_Users_UserId",
                table: "KeySales");

            migrationBuilder.DropForeignKey(
                name: "FK_LastFiles_Users_UserId",
                table: "LastFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ListErrors_Users_UserId1",
                table: "ListErrors");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Users_UserId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_TelegramUsers_Users_UserId",
                table: "TelegramUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeCodes_Users_UserId",
                table: "TimeCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserResources_Users_UserId",
                table: "UserResources");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFiles_Users_UserId",
                table: "UsersFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersTariffs_Users_UserId",
                table: "UsersTariffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "CeUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CeUsers",
                table: "CeUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_CeUsers_UserId",
                table: "Files",
                column: "UserId",
                principalTable: "CeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FileStatistics_CeUsers_UserId",
                table: "FileStatistics",
                column: "UserId",
                principalTable: "CeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KeySaleInvoices_CeUsers_UserId",
                table: "KeySaleInvoices",
                column: "UserId",
                principalTable: "CeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KeySales_CeUsers_UserId",
                table: "KeySales",
                column: "UserId",
                principalTable: "CeUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LastFiles_CeUsers_UserId",
                table: "LastFiles",
                column: "UserId",
                principalTable: "CeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListErrors_CeUsers_UserId1",
                table: "ListErrors",
                column: "UserId1",
                principalTable: "CeUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_CeUsers_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "CeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_CeUsers_UserId",
                table: "Sessions",
                column: "UserId",
                principalTable: "CeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TelegramUsers_CeUsers_UserId",
                table: "TelegramUsers",
                column: "UserId",
                principalTable: "CeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeCodes_CeUsers_UserId",
                table: "TimeCodes",
                column: "UserId",
                principalTable: "CeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserResources_CeUsers_UserId",
                table: "UserResources",
                column: "UserId",
                principalTable: "CeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFiles_CeUsers_UserId",
                table: "UsersFiles",
                column: "UserId",
                principalTable: "CeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersTariffs_CeUsers_UserId",
                table: "UsersTariffs",
                column: "UserId",
                principalTable: "CeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_CeUsers_UserId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_FileStatistics_CeUsers_UserId",
                table: "FileStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_KeySaleInvoices_CeUsers_UserId",
                table: "KeySaleInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_KeySales_CeUsers_UserId",
                table: "KeySales");

            migrationBuilder.DropForeignKey(
                name: "FK_LastFiles_CeUsers_UserId",
                table: "LastFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ListErrors_CeUsers_UserId1",
                table: "ListErrors");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_CeUsers_UserId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_CeUsers_UserId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_TelegramUsers_CeUsers_UserId",
                table: "TelegramUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeCodes_CeUsers_UserId",
                table: "TimeCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserResources_CeUsers_UserId",
                table: "UserResources");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFiles_CeUsers_UserId",
                table: "UsersFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersTariffs_CeUsers_UserId",
                table: "UsersTariffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CeUsers",
                table: "CeUsers");

            migrationBuilder.RenameTable(
                name: "CeUsers",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_UserId",
                table: "Files",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FileStatistics_Users_UserId",
                table: "FileStatistics",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KeySaleInvoices_Users_UserId",
                table: "KeySaleInvoices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KeySales_Users_UserId",
                table: "KeySales",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LastFiles_Users_UserId",
                table: "LastFiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListErrors_Users_UserId1",
                table: "ListErrors",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Users_UserId",
                table: "Sessions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TelegramUsers_Users_UserId",
                table: "TelegramUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeCodes_Users_UserId",
                table: "TimeCodes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserResources_Users_UserId",
                table: "UserResources",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFiles_Users_UserId",
                table: "UsersFiles",
                column: "UserId",
                principalTable: "Users",
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
    }
}
