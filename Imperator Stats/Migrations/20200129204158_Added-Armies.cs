using Microsoft.EntityFrameworkCore.Migrations;

namespace ImperatorStats.Migrations
{
    public partial class AddedArmies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Army",
                columns: table => new
                {
                    SaveId = table.Column<int>(nullable: false),
                    ArmyId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Morale = table.Column<double>(nullable: false),
                    Experience = table.Column<double>(nullable: false),
                    Strength = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Army", x => new { x.SaveId, x.ArmyId });
                    table.ForeignKey(
                        name: "FK_Army_Saves_SaveId",
                        column: x => x.SaveId,
                        principalTable: "Saves",
                        principalColumn: "SaveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Army_Countries_SaveId_CountryId",
                        columns: x => new { x.SaveId, x.CountryId },
                        principalTable: "Countries",
                        principalColumns: new[] { "SaveId", "CountryId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Army_SaveId_CountryId",
                table: "Army",
                columns: new[] { "SaveId", "CountryId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Army");
        }
    }
}
