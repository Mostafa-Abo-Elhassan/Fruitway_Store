using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fruitway_Store.Migrations
{
    /// <inheritdoc />
    public partial class jfdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTatol = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails", x => x.OrderDetailsId);
                    table.ForeignKey(
                        name: "FK_orderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b892d2e-2158-4170-91ec-08839cd0f4d4",
                column: "ConcurrencyStamp",
                value: "1bcd969a-517f-48c4-b8ef-6770919d11e4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a768bee-f40e-4183-9736-2c0cae0ba9f3",
                column: "ConcurrencyStamp",
                value: "030bb8c2-9079-4017-8965-307cedf40102");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b5649ea-6db6-482a-a83e-73633a72c2ce",
                column: "ConcurrencyStamp",
                value: "ff158e9b-eafa-4ba8-811a-607dd6be5c2f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20F5B72B-5F5E-4D40-A45B-509A01FF187F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "555ce42d-6abb-4d4d-9710-e43f5a2c7901", "AQAAAAIAAYagAAAAEP+KfwYNZMwXFBM+IwFuZmHS+Vb3X52AtSu/aDpWOKSP+53CE5E2qdXXr6YU0kjH/w==", "e8793e4d-ea70-4402-976d-c5e395662927" });

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_OrderId",
                table: "orderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_ProductId",
                table: "orderDetails",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

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
    }
}
