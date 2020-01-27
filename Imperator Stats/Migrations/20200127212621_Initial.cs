using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImperatorStats.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Saves",
                columns: table => new
                {
                    SaveId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SaveKey = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saves", x => x.SaveId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    SaveId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    HistoricalTag = table.Column<string>(nullable: true),
                    FlagTag = table.Column<string>(nullable: true),
                    Manpower = table.Column<double>(nullable: false),
                    Gold = table.Column<double>(nullable: false),
                    Stability = table.Column<double>(nullable: false),
                    Tyranny = table.Column<double>(nullable: false),
                    WarExhaustion = table.Column<double>(nullable: false),
                    AggressiveExpansion = table.Column<double>(nullable: false),
                    PoliticalInfluence = table.Column<double>(nullable: false),
                    MilitaryExperience = table.Column<double>(nullable: false),
                    StartingPopulation = table.Column<int>(nullable: false),
                    MonthlyManpower = table.Column<double>(nullable: false),
                    CurrentIncome = table.Column<double>(nullable: false),
                    EstimatedMonthlyIncome = table.Column<double>(nullable: false),
                    AveragedIncome = table.Column<double>(nullable: false),
                    ReligiousUnity = table.Column<double>(nullable: false),
                    MaxManpower = table.Column<double>(nullable: false),
                    ForeignReligionPops = table.Column<int>(nullable: false),
                    TotalPopulation = table.Column<int>(nullable: false),
                    TotalCohorts = table.Column<int>(nullable: false),
                    LoyalPops = table.Column<int>(nullable: false),
                    LoyalCohorts = table.Column<int>(nullable: false),
                    TotalPowerBase = table.Column<double>(nullable: false),
                    Legitimacy = table.Column<double>(nullable: false),
                    Centralization = table.Column<double>(nullable: false),
                    LastWar = table.Column<DateTime>(nullable: false),
                    LastBattleWon = table.Column<DateTime>(nullable: false),
                    LastMonthIncome = table.Column<double>(nullable: false),
                    AccumulatedManpower = table.Column<double>(nullable: false),
                    AccumulatedGold = table.Column<double>(nullable: false),
                    AccumulatedStability = table.Column<double>(nullable: false),
                    AccumulatedTyranny = table.Column<double>(nullable: false),
                    AccumulatedWarExhaustion = table.Column<double>(nullable: false),
                    AccumulatedAggressiveExpansion = table.Column<double>(nullable: false),
                    AccumulatedPoliticalInfluence = table.Column<double>(nullable: false),
                    AccumulatedMilitaryExperience = table.Column<double>(nullable: false),
                    SpentManpower = table.Column<double>(nullable: false),
                    SpentGold = table.Column<double>(nullable: false),
                    SpentStability = table.Column<double>(nullable: false),
                    SpentTyranny = table.Column<double>(nullable: false),
                    SpentWarExhaustion = table.Column<double>(nullable: false),
                    SpentAggressiveExpansion = table.Column<double>(nullable: false),
                    SpentPoliticalInfluence = table.Column<double>(nullable: false),
                    SpentMilitaryExperience = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => new { x.SaveId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_Countries_Saves_SaveId",
                        column: x => x.SaveId,
                        principalTable: "Saves",
                        principalColumn: "SaveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    SaveId = table.Column<int>(nullable: false),
                    FamilyId = table.Column<int>(nullable: false),
                    Key = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => new { x.SaveId, x.FamilyId });
                    table.ForeignKey(
                        name: "FK_Families_Saves_SaveId",
                        column: x => x.SaveId,
                        principalTable: "Saves",
                        principalColumn: "SaveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryPlayers",
                columns: table => new
                {
                    SaveId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    PlayerName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryPlayers", x => new { x.SaveId, x.CountryId, x.PlayerName });
                    table.ForeignKey(
                        name: "FK_CountryPlayers_Countries_SaveId_CountryId",
                        columns: x => new { x.SaveId, x.CountryId },
                        principalTable: "Countries",
                        principalColumns: new[] { "SaveId", "CountryId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryTechnologies",
                columns: table => new
                {
                    SaveId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Progress = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTechnologies", x => new { x.SaveId, x.CountryId, x.Type });
                    table.ForeignKey(
                        name: "FK_CountryTechnologies_Countries_SaveId_CountryId",
                        columns: x => new { x.SaveId, x.CountryId },
                        principalTable: "Countries",
                        principalColumns: new[] { "SaveId", "CountryId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    SaveId = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: false),
                    OriginalCulture = table.Column<string>(nullable: true),
                    OriginalReligion = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    CivilizationValue = table.Column<int>(nullable: false),
                    TradeGood = table.Column<string>(nullable: true),
                    OwnerSaveId = table.Column<int>(nullable: true),
                    OwnerCountryId = table.Column<int>(nullable: true),
                    ControllerSaveId = table.Column<int>(nullable: true),
                    ControllerCountryId = table.Column<int>(nullable: true),
                    PreviousControllerSaveId = table.Column<int>(nullable: true),
                    PreviousControllerCountryId = table.Column<int>(nullable: true),
                    LastOwnerChange = table.Column<DateTime>(nullable: false),
                    LastControllerChange = table.Column<DateTime>(nullable: false),
                    Rank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => new { x.SaveId, x.ProvinceId });
                    table.ForeignKey(
                        name: "FK_Provinces_Saves_SaveId",
                        column: x => x.SaveId,
                        principalTable: "Saves",
                        principalColumn: "SaveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_ControllerSaveId_ControllerCountryId",
                        columns: x => new { x.ControllerSaveId, x.ControllerCountryId },
                        principalTable: "Countries",
                        principalColumns: new[] { "SaveId", "CountryId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_OwnerSaveId_OwnerCountryId",
                        columns: x => new { x.OwnerSaveId, x.OwnerCountryId },
                        principalTable: "Countries",
                        principalColumns: new[] { "SaveId", "CountryId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_PreviousControllerSaveId_PreviousControl~",
                        columns: x => new { x.PreviousControllerSaveId, x.PreviousControllerCountryId },
                        principalTable: "Countries",
                        principalColumns: new[] { "SaveId", "CountryId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pops",
                columns: table => new
                {
                    SaveId = table.Column<int>(nullable: false),
                    PopId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Culture = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    ProvinceSaveId = table.Column<int>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pops", x => new { x.SaveId, x.PopId });
                    table.ForeignKey(
                        name: "FK_Pops_Saves_SaveId",
                        column: x => x.SaveId,
                        principalTable: "Saves",
                        principalColumn: "SaveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pops_Provinces_ProvinceSaveId_ProvinceId",
                        columns: x => new { x.ProvinceSaveId, x.ProvinceId },
                        principalTable: "Provinces",
                        principalColumns: new[] { "SaveId", "ProvinceId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pops_ProvinceSaveId_ProvinceId",
                table: "Pops",
                columns: new[] { "ProvinceSaveId", "ProvinceId" });

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_ControllerSaveId_ControllerCountryId",
                table: "Provinces",
                columns: new[] { "ControllerSaveId", "ControllerCountryId" });

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_OwnerSaveId_OwnerCountryId",
                table: "Provinces",
                columns: new[] { "OwnerSaveId", "OwnerCountryId" });

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_PreviousControllerSaveId_PreviousControllerCountry~",
                table: "Provinces",
                columns: new[] { "PreviousControllerSaveId", "PreviousControllerCountryId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryPlayers");

            migrationBuilder.DropTable(
                name: "CountryTechnologies");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "Pops");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Saves");
        }
    }
}
