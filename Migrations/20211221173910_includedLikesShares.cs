using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class includedLikesShares : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Posts_OrigId",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Posts_ResponseId",
                table: "Replies");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.CreateTable(
                name: "TextPosts",
                columns: table => new
                {
                    TextPostId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(maxLength: 140, nullable: false),
                    CreaterId = table.Column<int>(nullable: false),
                    CreatorUserId = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextPosts", x => x.TextPostId);
                    table.ForeignKey(
                        name: "FK_TextPosts_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    LikeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    LikerId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.LikeId);
                    table.ForeignKey(
                        name: "FK_Likes_Users_LikerId",
                        column: x => x.LikerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_TextPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "TextPosts",
                        principalColumn: "TextPostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shares",
                columns: table => new
                {
                    ShareId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    SharerId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shares", x => x.ShareId);
                    table.ForeignKey(
                        name: "FK_Shares_TextPosts_PostId",
                        column: x => x.PostId,
                        principalTable: "TextPosts",
                        principalColumn: "TextPostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shares_Users_SharerId",
                        column: x => x.SharerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikerId",
                table: "Likes",
                column: "LikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Shares_PostId",
                table: "Shares",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Shares_SharerId",
                table: "Shares",
                column: "SharerId");

            migrationBuilder.CreateIndex(
                name: "IX_TextPosts_CreatorUserId",
                table: "TextPosts",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_TextPosts_OrigId",
                table: "Replies",
                column: "OrigId",
                principalTable: "TextPosts",
                principalColumn: "TextPostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_TextPosts_ResponseId",
                table: "Replies",
                column: "ResponseId",
                principalTable: "TextPosts",
                principalColumn: "TextPostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_TextPosts_OrigId",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_TextPosts_ResponseId",
                table: "Replies");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Shares");

            migrationBuilder.DropTable(
                name: "TextPosts");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreaterId = table.Column<int>(type: "int", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CreatorUserId",
                table: "Posts",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Posts_OrigId",
                table: "Replies",
                column: "OrigId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Posts_ResponseId",
                table: "Replies",
                column: "ResponseId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
