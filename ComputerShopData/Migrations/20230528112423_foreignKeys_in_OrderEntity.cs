using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerShopData.Migrations
{
    /// <inheritdoc />
    public partial class foreignKeys_in_OrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserEntityId",
                table: "Orders",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserEntityId",
                table: "Orders",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserEntityId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserEntityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Orders");
        }
    }
}
