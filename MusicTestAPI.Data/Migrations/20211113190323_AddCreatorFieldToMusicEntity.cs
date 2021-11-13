using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicTestAPI.Data.Migrations
{
    public partial class AddCreatorFieldToMusicEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Song",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Song",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Song_CreatorId",
                table: "Song",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Users_CreatorId",
                table: "Song",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_Users_CreatorId",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_Song_CreatorId",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Song");
        }
    }
}
