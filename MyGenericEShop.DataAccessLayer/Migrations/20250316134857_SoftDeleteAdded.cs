using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGenericEShop.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TelegramTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Role",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Review",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Price",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Payment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "OrderItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "CategoryType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "CartItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Cart",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TelegramTokens");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "CategoryType");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Cart");
        }
    }
}
