using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoTaskManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTodoCategoryTodoRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "dbo",
                table: "Todo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todo_CategoryId",
                schema: "dbo",
                table: "Todo",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_TodoCategory_CategoryId",
                schema: "dbo",
                table: "Todo",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "TodoCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_TodoCategory_CategoryId",
                schema: "dbo",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Todo_CategoryId",
                schema: "dbo",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "Todo");
        }
    }
}
