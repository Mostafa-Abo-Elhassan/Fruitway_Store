using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fruitway_Store.Migrations
{
    /// <inheritdoc />
    public partial class carts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShappingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    shappingcartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShappingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShappingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b892d2e-2158-4170-91ec-08839cd0f4d4",
                column: "ConcurrencyStamp",
                value: "e783f900-7134-44ac-93cc-fb5c69bae7d1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a768bee-f40e-4183-9736-2c0cae0ba9f3",
                column: "ConcurrencyStamp",
                value: "64af2329-5ffb-4736-9d6b-baddad905af1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b5649ea-6db6-482a-a83e-73633a72c2ce",
                column: "ConcurrencyStamp",
                value: "073ad221-3444-4f39-808c-3d233e0b04c2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20F5B72B-5F5E-4D40-A45B-509A01FF187F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29bcf245-786e-4307-ac5b-b7a73b0b2d0e", "AQAAAAIAAYagAAAAENQHYXVZBQGIRPB2WHTPm4zE6ISbWl5+qkyGZHsA/IMLonZufuwz9gFWCm7mNaaEJg==", "8746a318-b8e2-4e76-ba1e-46cf56cdc1c2" });

            migrationBuilder.CreateIndex(
                name: "IX_ShappingCarts_ProductId",
                table: "ShappingCarts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShappingCarts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b892d2e-2158-4170-91ec-08839cd0f4d4",
                column: "ConcurrencyStamp",
                value: "46c219e5-d934-4aa6-8c38-3b7c6f4efa0b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a768bee-f40e-4183-9736-2c0cae0ba9f3",
                column: "ConcurrencyStamp",
                value: "10cbffb2-a157-44f2-9ccb-ad5ba7102334");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b5649ea-6db6-482a-a83e-73633a72c2ce",
                column: "ConcurrencyStamp",
                value: "6c0157b0-50a7-4ceb-a1fb-95fbcfd632db");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20F5B72B-5F5E-4D40-A45B-509A01FF187F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8df4193-ce13-45c0-9b06-98021f911817", "AQAAAAIAAYagAAAAELX87bnNpKP9G+sS7OT3ZE1tZRWxoah1hixEO5clzsyzx/lyWvkr+aVOJx+Osee9Jg==", "4dfbcefc-d58d-4a34-97e8-2d9f749b875d" });
        }
    }
}
