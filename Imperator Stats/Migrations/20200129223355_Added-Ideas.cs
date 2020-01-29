using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImperatorStats.Migrations
{
    public partial class AddedIdeas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryIdeas",
                columns: table => new
                {
                    SaveId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryIdeas", x => new { x.SaveId, x.CountryId, x.Name });
                    table.ForeignKey(
                        name: "FK_CountryIdeas_Countries_SaveId_CountryId",
                        columns: x => new { x.SaveId, x.CountryId },
                        principalTable: "Countries",
                        principalColumns: new[] { "SaveId", "CountryId" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryIdeas");
        }
    }
}
