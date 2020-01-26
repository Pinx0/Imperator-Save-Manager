using Microsoft.EntityFrameworkCore.Migrations;

namespace ImperatorStats.Migrations
{
    public partial class CountryPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryPlayer",
                columns: table => new
                {
                    SaveId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    PlayerName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryPlayer", x => new { x.SaveId, x.CountryId, x.PlayerName });
                    table.ForeignKey(
                        name: "FK_CountryPlayer_Countries_SaveId_CountryId",
                        columns: x => new { x.SaveId, x.CountryId },
                        principalTable: "Countries",
                        principalColumns: new[] { "SaveId", "CountryId" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryPlayer");
        }
    }
}
