using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoTaskManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTodoItemIdDataTypeAndAddDueDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                schema: "dbo",
                table: "Todo");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "Todo",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                schema: "dbo",
                table: "Todo",
                type: "datetime",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                schema: "dbo",
                table: "Todo");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "Todo",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                schema: "dbo",
                table: "Todo",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
