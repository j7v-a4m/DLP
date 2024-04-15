using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DLP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactInfo",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo_PhoneNumber",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo_TelegramLink",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo_WebSiteUrl",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo_YouTubeUrl",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactInfo_PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ContactInfo_TelegramLink",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ContactInfo_WebSiteUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ContactInfo_YouTubeUrl",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
