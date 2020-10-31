using Microsoft.EntityFrameworkCore.Migrations;

namespace CommunityOpenChatSite.Data.Migrations
{
    public partial class AddPhotoForms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoPosts",
                columns: table => new
                {
                    TextForumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForumName = table.Column<string>(nullable: true),
                    ForumDescription = table.Column<string>(nullable: true),
                    EmbedCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoPosts", x => x.TextForumId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoPosts");
        }
    }
}
