using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class CartLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLine_Products_ProductId",
                table: "CartLine");

            migrationBuilder.DropIndex(
                name: "IX_CartLine_ProductId",
                table: "CartLine");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "CartLine",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "CartLine",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "CartLine",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "CartLine");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "CartLine");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "CartLine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_ProductId",
                table: "CartLine",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartLine_Products_ProductId",
                table: "CartLine",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
