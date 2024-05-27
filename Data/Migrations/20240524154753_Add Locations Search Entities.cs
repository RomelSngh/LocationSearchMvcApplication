using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocationSearchApiMVCWithUsers.Data.Migrations
{
    public partial class AddLocationsSearchEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homecity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LocationImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dislike = table.Column<bool>(type: "bit", nullable: true),
                    venueid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    latitude = table.Column<double>(type: "float", nullable: true),
                    longitude = table.Column<double>(type: "float", nullable: true),
                    like = table.Column<bool>(type: "bit", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photos = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: true),
                    rating = table.Column<double>(type: "float", nullable: true),
                    restricted = table.Column<bool>(type: "bit", nullable: true),
                    storeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verified = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "LocationImages");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
