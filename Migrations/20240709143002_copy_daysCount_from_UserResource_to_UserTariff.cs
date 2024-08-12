using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarEdit_Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class copy_daysCount_from_UserResource_to_UserTariff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Перенос данных из UserResources в новое поле UsersTariffs
            migrationBuilder.Sql(
                @"
            UPDATE ut
            SET ut.Days = CAST(ur.Days AS int)
            FROM UsersTariffs ut
            INNER JOIN UserResources ur ON ut.UserId = ur.UserId
            ");

            // Удаление старого столбца Days из таблицы UserResources
            migrationBuilder.DropColumn(
                name: "Days",
                table: "UserResources");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.DropColumn(
            name: "Days",
            table: "UsersTariffs");

        migrationBuilder.AddColumn<double>(
            name: "Days",
            table: "UserResources",
            type: "float",
            nullable: false,
            defaultValue: 0.0);

        migrationBuilder.Sql(
            @"
            UPDATE ur
            SET ur.Days = CAST(ut.Days AS float)
            FROM UserResources ur
            INNER JOIN UsersTariffs ut ON ur.UserId = ut.UserId
            ");
        }
    }
}
