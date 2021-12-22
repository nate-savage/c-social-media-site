using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class FixedSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextPosts_Users_CreatorUserId",
                table: "TextPosts");

            migrationBuilder.DropIndex(
                name: "IX_TextPosts_CreatorUserId",
                table: "TextPosts");

            migrationBuilder.DropColumn(
                name: "CreaterId",
                table: "TextPosts");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "TextPosts");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "TextPosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TextPosts_CreatorId",
                table: "TextPosts",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TextPosts_Users_CreatorId",
                table: "TextPosts",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextPosts_Users_CreatorId",
                table: "TextPosts");

            migrationBuilder.DropIndex(
                name: "IX_TextPosts_CreatorId",
                table: "TextPosts");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "TextPosts");

            migrationBuilder.AddColumn<int>(
                name: "CreaterId",
                table: "TextPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatorUserId",
                table: "TextPosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextPosts_CreatorUserId",
                table: "TextPosts",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TextPosts_Users_CreatorUserId",
                table: "TextPosts",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
