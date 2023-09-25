using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryRentingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerIdPropertyForBookClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_customers_CustomerId",
                table: "books");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_books_customers_CustomerId",
                table: "books",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_customers_CustomerId",
                table: "books");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_books_customers_CustomerId",
                table: "books",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id");
        }
    }
}
