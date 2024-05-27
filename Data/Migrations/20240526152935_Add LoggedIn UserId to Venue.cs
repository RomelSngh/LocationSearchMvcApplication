using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocationSearchApiMVCWithUsers.Data.Migrations
{
    public partial class AddLoggedInUserIdtoVenue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "verified",
                table: "Venues",
                newName: "Verified");

            migrationBuilder.RenameColumn(
                name: "venueid",
                table: "Venues",
                newName: "Venueid");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "Venues",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "storeId",
                table: "Venues",
                newName: "StoreId");

            migrationBuilder.RenameColumn(
                name: "restricted",
                table: "Venues",
                newName: "Restricted");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "Venues",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Venues",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "photos",
                table: "Venues",
                newName: "Photos");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Venues",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Venues",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "like",
                table: "Venues",
                newName: "Like");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Venues",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "dislike",
                table: "Venues",
                newName: "Dislike");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Venues",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Venues",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "idnumber",
                table: "AppUsers",
                newName: "IdNumber");

            migrationBuilder.RenameColumn(
                name: "homecity",
                table: "AppUsers",
                newName: "Homecity");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "AppUsers",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "bio",
                table: "AppUsers",
                newName: "Bio");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AppUsers",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Venues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Venues");

            migrationBuilder.RenameColumn(
                name: "Verified",
                table: "Venues",
                newName: "verified");

            migrationBuilder.RenameColumn(
                name: "Venueid",
                table: "Venues",
                newName: "venueid");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Venues",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "Venues",
                newName: "storeId");

            migrationBuilder.RenameColumn(
                name: "Restricted",
                table: "Venues",
                newName: "restricted");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Venues",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Venues",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Photos",
                table: "Venues",
                newName: "photos");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Venues",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Venues",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Like",
                table: "Venues",
                newName: "like");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Venues",
                newName: "latitude");

            migrationBuilder.RenameColumn(
                name: "Dislike",
                table: "Venues",
                newName: "dislike");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Venues",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Venues",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "AppUsers",
                newName: "idnumber");

            migrationBuilder.RenameColumn(
                name: "Homecity",
                table: "AppUsers",
                newName: "homecity");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "AppUsers",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Bio",
                table: "AppUsers",
                newName: "bio");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppUsers",
                newName: "id");
        }
    }
}
