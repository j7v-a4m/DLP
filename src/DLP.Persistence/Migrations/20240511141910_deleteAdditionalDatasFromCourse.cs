using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DLP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deleteAdditionalDatasFromCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_Title_Summary_WhatYouWillLearn",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AboutCourse",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "InitialRequirements",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "WhatYouWillLearn",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutCourse",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "InitialRequirements",
                table: "Courses",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "WhatYouWillLearn",
                table: "Courses",
                type: "text[]",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Title_Summary_WhatYouWillLearn",
                table: "Courses",
                columns: new[] { "Title", "Summary", "WhatYouWillLearn" });
        }
    }
}
