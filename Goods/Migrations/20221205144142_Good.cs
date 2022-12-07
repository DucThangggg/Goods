using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Goods.Migrations
{
    /// <inheritdoc />
    public partial class Good : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "items_Entities",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NumberReview = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductRemain = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items_Entities", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "user_Entities",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Entities", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "carts_Entities",
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductAllPrice = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts_Entities", x => x.CartsId);
                    table.ForeignKey(
                        name: "FK_carts_Entities_items_Entities_ProductId",
                        column: x => x.ProductId,
                        principalTable: "items_Entities",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carts_Entities_user_Entities_UserId",
                        column: x => x.UserId,
                        principalTable: "user_Entities",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders_Entities",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdersDate = table.Column<DateTime>(type: "date", nullable: false),
                    ShipName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShipAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShipPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SumOfPrice = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders_Entities", x => x.OrdersId);
                    table.ForeignKey(
                        name: "FK_orders_Entities_user_Entities_UserId",
                        column: x => x.UserId,
                        principalTable: "user_Entities",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews_Entities",
                columns: table => new
                {
                    ReviewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews_Entities", x => x.ReviewsId);
                    table.ForeignKey(
                        name: "FK_reviews_Entities_items_Entities_ProductId",
                        column: x => x.ProductId,
                        principalTable: "items_Entities",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviews_Entities_user_Entities_UserId",
                        column: x => x.UserId,
                        principalTable: "user_Entities",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderDetails_Entities",
                columns: table => new
                {
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ProductAllPrice = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails_Entities", x => x.OrderDetailsId);
                    table.ForeignKey(
                        name: "FK_orderDetails_Entities_items_Entities_ProductId",
                        column: x => x.ProductId,
                        principalTable: "items_Entities",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderDetails_Entities_orders_Entities_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "orders_Entities",
                        principalColumn: "OrdersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carts_Entities_ProductId",
                table: "carts_Entities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_carts_Entities_UserId",
                table: "carts_Entities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_Entities_OrdersId",
                table: "orderDetails_Entities",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_Entities_ProductId",
                table: "orderDetails_Entities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_Entities_UserId",
                table: "orders_Entities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_Entities_ProductId",
                table: "reviews_Entities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_Entities_UserId",
                table: "reviews_Entities",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carts_Entities");

            migrationBuilder.DropTable(
                name: "orderDetails_Entities");

            migrationBuilder.DropTable(
                name: "reviews_Entities");

            migrationBuilder.DropTable(
                name: "orders_Entities");

            migrationBuilder.DropTable(
                name: "items_Entities");

            migrationBuilder.DropTable(
                name: "user_Entities");
        }
    }
}
