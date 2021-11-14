using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicTestAPI.Data.Migrations
{
    public partial class AddCommonFieldsInClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Song",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Albums");
        }
    }
}
