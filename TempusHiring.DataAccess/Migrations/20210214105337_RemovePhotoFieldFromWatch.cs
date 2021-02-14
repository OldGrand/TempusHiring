using Microsoft.EntityFrameworkCore.Migrations;

namespace TempusHiring.DataAccess.Migrations
{
    public partial class RemovePhotoFieldFromWatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Watches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Watches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
