using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kapizoo.Migrations
{
    public partial class AlterCapybara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Capybaras",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Capybaras");
        }
    }
}
