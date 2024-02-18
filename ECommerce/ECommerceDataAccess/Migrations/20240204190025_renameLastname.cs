using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceDataAccess.Migrations
{
    public partial class renameLastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastame",
                table: "AspNetUsers",
                newName: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Lastame");
        }
    }
}
