using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryItems.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "LibraryItems",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LengthOfBooking",
                table: "LibraryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "LibraryItems");

            migrationBuilder.DropColumn(
                name: "LengthOfBooking",
                table: "LibraryItems");
        }
    }
}
