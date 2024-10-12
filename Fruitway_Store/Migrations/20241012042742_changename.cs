using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fruitway_Store.Migrations
{
    /// <inheritdoc />
    public partial class changename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "shappingcartId",
                table: "ShappingCarts",
                newName: "ShoppingCartId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b892d2e-2158-4170-91ec-08839cd0f4d4",
                column: "ConcurrencyStamp",
                value: "9082780b-8ddd-45b0-9caa-3ba459b02b55");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a768bee-f40e-4183-9736-2c0cae0ba9f3",
                column: "ConcurrencyStamp",
                value: "4a70624e-185f-4827-a60b-670f18d89fb8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b5649ea-6db6-482a-a83e-73633a72c2ce",
                column: "ConcurrencyStamp",
                value: "a29fdaff-6c53-451c-a948-f79a8f861b1a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20F5B72B-5F5E-4D40-A45B-509A01FF187F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cc77117-4ebd-41a8-b95e-010975180bae", "AQAAAAIAAYagAAAAENHVLSXsUf+UL+hQYvvBCdDcXnDHvHQsLXeU70pRfnyB1qwislLuw/rFnL/ktTAm/Q==", "1cbbf47e-3594-44e5-9299-42959ef5a2c5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "ShappingCarts",
                newName: "shappingcartId");

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
        }
    }
}
