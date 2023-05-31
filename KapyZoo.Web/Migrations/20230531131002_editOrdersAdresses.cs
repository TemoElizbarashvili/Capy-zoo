using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KapyZoo.Web.Migrations
{
    public partial class editOrdersAdresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "addresLine3",
                table: "Orders",
                newName: "AddresLine3");

            migrationBuilder.RenameColumn(
                name: "addresLine2",
                table: "Orders",
                newName: "AddresLine2");

            migrationBuilder.RenameColumn(
                name: "addresLine1",
                table: "Orders",
                newName: "AddresLine1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddresLine3",
                table: "Orders",
                newName: "addresLine3");

            migrationBuilder.RenameColumn(
                name: "AddresLine2",
                table: "Orders",
                newName: "addresLine2");

            migrationBuilder.RenameColumn(
                name: "AddresLine1",
                table: "Orders",
                newName: "addresLine1");
        }
    }
}
