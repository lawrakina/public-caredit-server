using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Migrations
{
    /// <inheritdoc />
    public partial class change_session_type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListErrors_Users_UserId",
                table: "ListErrors");

            migrationBuilder.DropIndex(
                name: "IX_ListErrors_UserId",
                table: "ListErrors");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ListErrors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "ListErrors",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListErrors_UserId1",
                table: "ListErrors",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ListErrors_Users_UserId1",
                table: "ListErrors",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListErrors_Users_UserId1",
                table: "ListErrors");

            migrationBuilder.DropIndex(
                name: "IX_ListErrors_UserId1",
                table: "ListErrors");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ListErrors");

            migrationBuilder.AlterColumn<long>(
                name: "Value",
                table: "Sessions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "ListErrors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListErrors_UserId",
                table: "ListErrors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListErrors_Users_UserId",
                table: "ListErrors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
