using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocationSearchApiMVCWithUsers.Data.Migrations
{
    public partial class AddPhotoTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoTitle",
                table: "LocationImages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoTitle",
                table: "LocationImages");
        }
    }
}
