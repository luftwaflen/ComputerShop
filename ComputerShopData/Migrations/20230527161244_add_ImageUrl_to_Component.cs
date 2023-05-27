using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerShopData.Migrations
{
    /// <inheritdoc />
    public partial class add_ImageUrl_to_Component : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Components",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Components");
        }
    }
}
