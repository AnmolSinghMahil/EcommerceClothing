using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceClothing.Migrations
{
    /// <inheritdoc />
    public partial class updateProductIdCartModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductIdID",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductIdID",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "ProductIdID",
                table: "CartItems",
                newName: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItems",
                newName: "ProductIdID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductIdID",
                table: "CartItems",
                column: "ProductIdID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductIdID",
                table: "CartItems",
                column: "ProductIdID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
