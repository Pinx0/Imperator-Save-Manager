using System;
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
                    SaveId = table.Column<string>(maxLength: 50, nullable: false),
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
                    SaveId = table.Column<string>(maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    HistoricalTag = table.Column<string>(nullable: true),
                    FlagTag = table.Column<string>(nullable: true),
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
                    LastBattleWon = table.Column<DateTime>(nullable: false)
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
                    SaveId = table.Column<string>(maxLength: 50, nullable: false),
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
                name: "CountryCurrencyData",
                columns: table => new
                {
                    SaveId = table.Column<string>(maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Manpower = table.Column<double>(nullable: false),
                    Gold = table.Column<double>(nullable: false),
                    Stability = table.Column<double>(nullable: false),
                    Tyranny = table.Column<double>(nullable: false),
                    WarExhaustion = table.Column<double>(nullable: false),
                    AggressiveExpansion = table.Column<double>(nullable: false),
                    PoliticalInfluence = table.Column<double>(nullable: false),
                    MilitaryExperience = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCurrencyData", x => new { x.SaveId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_CountryCurrencyData_Countries_SaveId_CountryId",
                        columns: x => new { x.SaveId, x.CountryId },
                        principalTable: "Countries",
                        principalColumns: new[] { "SaveId", "CountryId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryEconomy",
                columns: table => new
                {
                    SaveId = table.Column<string>(maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    AccumulatedSaveId = table.Column<string>(nullable: true),
                    AccumulatedCountryId = table.Column<int>(nullable: true),
                    AccumulatedType = table.Column<int>(nullable: true),
                    SpentSaveId = table.Column<string>(nullable: true),
                    SpentCountryId = table.Column<int>(nullable: true),
                    SpentType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryEconomy", x => new { x.SaveId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_CountryEconomy_Countries_SaveId_CountryId",
                        columns: x => new { x.SaveId, x.CountryId },
                        principalTable: "Countries",
                        principalColumns: new[] { "SaveId", "CountryId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryEconomyTelemetry",
                columns: table => new
                {
                    SaveId = table.Column<string>(maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Manpower = table.Column<double>(nullable: false),
                    Gold = table.Column<double>(nullable: false),
                    Stability = table.Column<double>(nullable: false),
                    Tyranny = table.Column<double>(nullable: false),
                    WarExhaustion = table.Column<double>(nullable: false),
                    AggressiveExpansion = table.Column<double>(nullable: false),
                    PoliticalInfluence = table.Column<double>(nullable: false),
                    MilitaryExperience = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryEconomyTelemetry", x => new { x.SaveId, x.CountryId, x.Type });
                    table.ForeignKey(
                        name: "FK_CountryEconomyTelemetry_CountryEconomy_SaveId_CountryId",
                        columns: x => new { x.SaveId, x.CountryId },
                        principalTable: "CountryEconomy",
                        principalColumns: new[] { "SaveId", "CountryId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryTechnologies",
                columns: table => new
                {
                    SaveId = table.Column<string>(maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    MilitarySaveId = table.Column<string>(nullable: true),
                    MilitaryCountryId = table.Column<int>(nullable: true),
                    MilitaryType = table.Column<int>(nullable: true),
                    CivicSaveId = table.Column<string>(nullable: true),
                    CivicCountryId = table.Column<int>(nullable: true),
                    CivicType = table.Column<int>(nullable: true),
                    OratorySaveId = table.Column<string>(nullable: true),
                    OratoryCountryId = table.Column<int>(nullable: true),
                    OratoryType = table.Column<int>(nullable: true),
                    ReligiousSaveId = table.Column<string>(nullable: true),
                    ReligiousCountryId = table.Column<int>(nullable: true),
                    ReligiousType = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "CountryTechnology",
                columns: table => new
                {
                    SaveId = table.Column<string>(maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Progress = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTechnology", x => new { x.SaveId, x.CountryId, x.Type });
                    table.ForeignKey(
                        name: "FK_CountryTechnology_CountryTechnologies_SaveId_CountryId",
                        columns: x => new { x.SaveId, x.CountryId },
                        principalTable: "CountryTechnologies",
                        principalColumns: new[] { "SaveId", "CountryId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryEconomy_AccumulatedSaveId_AccumulatedCountryId_Accumu~",
                table: "CountryEconomy",
                columns: new[] { "AccumulatedSaveId", "AccumulatedCountryId", "AccumulatedType" });

            migrationBuilder.CreateIndex(
                name: "IX_CountryEconomy_SpentSaveId_SpentCountryId_SpentType",
                table: "CountryEconomy",
                columns: new[] { "SpentSaveId", "SpentCountryId", "SpentType" });

            migrationBuilder.CreateIndex(
                name: "IX_CountryTechnologies_CivicSaveId_CivicCountryId_CivicType",
                table: "CountryTechnologies",
                columns: new[] { "CivicSaveId", "CivicCountryId", "CivicType" });

            migrationBuilder.CreateIndex(
                name: "IX_CountryTechnologies_MilitarySaveId_MilitaryCountryId_Militar~",
                table: "CountryTechnologies",
                columns: new[] { "MilitarySaveId", "MilitaryCountryId", "MilitaryType" });

            migrationBuilder.CreateIndex(
                name: "IX_CountryTechnologies_OratorySaveId_OratoryCountryId_OratoryTy~",
                table: "CountryTechnologies",
                columns: new[] { "OratorySaveId", "OratoryCountryId", "OratoryType" });

            migrationBuilder.CreateIndex(
                name: "IX_CountryTechnologies_ReligiousSaveId_ReligiousCountryId_Relig~",
                table: "CountryTechnologies",
                columns: new[] { "ReligiousSaveId", "ReligiousCountryId", "ReligiousType" });

            migrationBuilder.AddForeignKey(
                name: "FK_CountryEconomy_CountryEconomyTelemetry_AccumulatedSaveId_Acc~",
                table: "CountryEconomy",
                columns: new[] { "AccumulatedSaveId", "AccumulatedCountryId", "AccumulatedType" },
                principalTable: "CountryEconomyTelemetry",
                principalColumns: new[] { "SaveId", "CountryId", "Type" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryEconomy_CountryEconomyTelemetry_SpentSaveId_SpentCoun~",
                table: "CountryEconomy",
                columns: new[] { "SpentSaveId", "SpentCountryId", "SpentType" },
                principalTable: "CountryEconomyTelemetry",
                principalColumns: new[] { "SaveId", "CountryId", "Type" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryTechnologies_CountryTechnology_CivicSaveId_CivicCount~",
                table: "CountryTechnologies",
                columns: new[] { "CivicSaveId", "CivicCountryId", "CivicType" },
                principalTable: "CountryTechnology",
                principalColumns: new[] { "SaveId", "CountryId", "Type" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryTechnologies_CountryTechnology_MilitarySaveId_Militar~",
                table: "CountryTechnologies",
                columns: new[] { "MilitarySaveId", "MilitaryCountryId", "MilitaryType" },
                principalTable: "CountryTechnology",
                principalColumns: new[] { "SaveId", "CountryId", "Type" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryTechnologies_CountryTechnology_OratorySaveId_OratoryC~",
                table: "CountryTechnologies",
                columns: new[] { "OratorySaveId", "OratoryCountryId", "OratoryType" },
                principalTable: "CountryTechnology",
                principalColumns: new[] { "SaveId", "CountryId", "Type" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryTechnologies_CountryTechnology_ReligiousSaveId_Religi~",
                table: "CountryTechnologies",
                columns: new[] { "ReligiousSaveId", "ReligiousCountryId", "ReligiousType" },
                principalTable: "CountryTechnology",
                principalColumns: new[] { "SaveId", "CountryId", "Type" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Saves_SaveId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryEconomy_Countries_SaveId_CountryId",
                table: "CountryEconomy");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryTechnologies_Countries_SaveId_CountryId",
                table: "CountryTechnologies");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryEconomy_CountryEconomyTelemetry_AccumulatedSaveId_Acc~",
                table: "CountryEconomy");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryEconomy_CountryEconomyTelemetry_SpentSaveId_SpentCoun~",
                table: "CountryEconomy");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryTechnologies_CountryTechnology_CivicSaveId_CivicCount~",
                table: "CountryTechnologies");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryTechnologies_CountryTechnology_MilitarySaveId_Militar~",
                table: "CountryTechnologies");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryTechnologies_CountryTechnology_OratorySaveId_OratoryC~",
                table: "CountryTechnologies");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryTechnologies_CountryTechnology_ReligiousSaveId_Religi~",
                table: "CountryTechnologies");

            migrationBuilder.DropTable(
                name: "CountryCurrencyData");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "Saves");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CountryEconomyTelemetry");

            migrationBuilder.DropTable(
                name: "CountryEconomy");

            migrationBuilder.DropTable(
                name: "CountryTechnology");

            migrationBuilder.DropTable(
                name: "CountryTechnologies");
        }
    }
}
