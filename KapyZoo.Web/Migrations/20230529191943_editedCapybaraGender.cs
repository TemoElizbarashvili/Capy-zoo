using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KapyZoo.Web.Migrations
{
    public partial class editedCapybaraGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Capybaras",
                newName: "Gender");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Capybaras",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Capybaras",
                newName: "gender");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "Capybaras",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
