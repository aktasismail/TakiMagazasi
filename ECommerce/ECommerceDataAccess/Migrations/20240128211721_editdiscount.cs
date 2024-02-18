using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceDataAccess.Migrations
{
    public partial class editdiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Discounts",
                newName: "CouponCode");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Discounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CouponCode",
                table: "Discounts",
                newName: "ImageUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Amount",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
