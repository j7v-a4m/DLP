using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DLP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deleteContactInfoAndDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "Users");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "Users",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

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
    }
}
