using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseProject.Migrations
{
    /// <inheritdoc />
    public partial class updateOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_Orders_OrdersId",
                table: "OrdersItems");

            migrationBuilder.DropIndex(
                name: "IX_OrdersItems_OrdersId",
                table: "OrdersItems");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "OrdersItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "OrdersItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdersItems_OrdersId",
                table: "OrdersItems",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_Orders_OrdersId",
                table: "OrdersItems",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "OrdersId");
        }
    }
}
