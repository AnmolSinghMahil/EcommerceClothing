using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceClothing.Migrations
{
    /// <inheritdoc />
    public partial class updateShoppingCartCartItemModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ShoppingCart_ShoppingCartId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CartItemsId",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "CartItems",
                newName: "ShoppingCartID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ShoppingCartId",
                table: "CartItems",
                newName: "IX_CartItems_ShoppingCartID");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "ShoppingCart",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartID",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_UserID",
                table: "ShoppingCart",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ShoppingCart_ShoppingCartID",
                table: "CartItems",
                column: "ShoppingCartID",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserID",
                table: "ShoppingCart",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ShoppingCart_ShoppingCartID",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserID",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_UserID",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartID",
                table: "CartItems",
                newName: "ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ShoppingCartID",
                table: "CartItems",
                newName: "IX_CartItems_ShoppingCartId");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "ShoppingCart",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CartItemsId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartId",
                table: "CartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ShoppingCart_ShoppingCartId",
                table: "CartItems",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id");
        }
    }
}
