using Microsoft.EntityFrameworkCore.Migrations;

namespace ImperatorStats.Migrations
{
    public partial class Forth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryTechnology_CountryTechnologies_SaveId_CountryId",
                table: "CountryTechnology");

            migrationBuilder.DropTable(
                name: "CountryTechnologies");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryTechnology_Countries_SaveId_CountryId",
                table: "CountryTechnology",
                columns: new[] { "SaveId", "CountryId" },
                principalTable: "Countries",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryTechnology_Countries_SaveId_CountryId",
                table: "CountryTechnology");

            migrationBuilder.CreateTable(
                name: "CountryTechnologies",
                columns: table => new
                {
                    SaveId = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTechnologies", x => new { x.SaveId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_CountryTechnologies_Countries_SaveId_CountryId",
                        columns: x => new { x.SaveId, x.CountryId },
                        principalTable: "Countries",
                        principalColumns: new[] { "SaveId", "CountryId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CountryTechnology_CountryTechnologies_SaveId_CountryId",
                table: "CountryTechnology",
                columns: new[] { "SaveId", "CountryId" },
                principalTable: "CountryTechnologies",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
