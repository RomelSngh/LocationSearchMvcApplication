using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocationSearchApiMVCWithUsers.Data.Migrations
{
    public partial class AddSearchandSearchType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlaceSearch",
                table: "Venues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceSearchCategory",
                table: "Venues",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceSearch",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "PlaceSearchCategory",
                table: "Venues");
        }
    }
}
