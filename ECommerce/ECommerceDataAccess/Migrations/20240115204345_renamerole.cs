using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceDataAccess.Migrations
{
    public partial class renamerole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cea0d67-8db3-42a3-8ce8-ae12c7ab6456");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b27e1453-eefc-4d7f-99e9-6b90d4933dda");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d50a9dd-8bef-49b7-8704-5e5535523178", "7fc942f2-7a40-4553-bc80-8a72772a8a2c", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb7fe07a-5c0a-42cc-8bf7-cd224a5b2507", "04854a4a-049f-4360-8e27-6c0d123f44ab", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d50a9dd-8bef-49b7-8704-5e5535523178");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb7fe07a-5c0a-42cc-8bf7-cd224a5b2507");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4cea0d67-8db3-42a3-8ce8-ae12c7ab6456", "1b289bf1-9ae0-4648-b883-7e4073023074", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b27e1453-eefc-4d7f-99e9-6b90d4933dda", "81d2d2b4-64d5-4f29-831a-398d2b67cc0d", "Admin", "ADMİN" });
        }
    }
}
