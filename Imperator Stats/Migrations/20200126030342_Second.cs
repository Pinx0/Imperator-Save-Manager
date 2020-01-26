using Microsoft.EntityFrameworkCore.Migrations;

namespace ImperatorStats.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryEconomy_CountryEconomyTelemetry_AccumulatedSaveId_Acc~",
                table: "CountryEconomy");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryEconomy_CountryEconomyTelemetry_SpentSaveId_SpentCoun~",
                table: "CountryEconomy");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryEconomyTelemetry_CountryEconomy_SaveId_CountryId",
                table: "CountryEconomyTelemetry");

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

            migrationBuilder.DropForeignKey(
                name: "FK_CountryTechnology_CountryTechnologies_SaveId_CountryId",
                table: "CountryTechnology");

            migrationBuilder.DropIndex(
                name: "IX_CountryTechnologies_CivicSaveId_CivicCountryId_CivicType",
                table: "CountryTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_CountryTechnologies_MilitarySaveId_MilitaryCountryId_Militar~",
                table: "CountryTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_CountryTechnologies_OratorySaveId_OratoryCountryId_OratoryTy~",
                table: "CountryTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_CountryTechnologies_ReligiousSaveId_ReligiousCountryId_Relig~",
                table: "CountryTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_CountryEconomy_AccumulatedSaveId_AccumulatedCountryId_Accumu~",
                table: "CountryEconomy");

            migrationBuilder.DropIndex(
                name: "IX_CountryEconomy_SpentSaveId_SpentCountryId_SpentType",
                table: "CountryEconomy");

            migrationBuilder.DropColumn(
                name: "CivicCountryId",
                table: "CountryTechnologies");

            migrationBuilder.DropColumn(
                name: "CivicSaveId",
                table: "CountryTechnologies");

            migrationBuilder.DropColumn(
                name: "CivicType",
                table: "CountryTechnologies");

            migrationBuilder.DropColumn(
                name: "MilitaryCountryId",
                table: "CountryTechnologies");

            migrationBuilder.DropColumn(
                name: "MilitarySaveId",
                table: "CountryTechnologies");

            migrationBuilder.DropColumn(
                name: "MilitaryType",
                table: "CountryTechnologies");

            migrationBuilder.DropColumn(
                name: "OratoryCountryId",
                table: "CountryTechnologies");

            migrationBuilder.DropColumn(
                name: "OratorySaveId",
                table: "CountryTechnologies");

            migrationBuilder.DropColumn(
                name: "OratoryType",
                table: "CountryTechnologies");

            migrationBuilder.DropColumn(
                name: "ReligiousCountryId",
                table: "CountryTechnologies");

            migrationBuilder.DropColumn(
                name: "ReligiousSaveId",
                table: "CountryTechnologies");

            migrationBuilder.DropColumn(
                name: "ReligiousType",
                table: "CountryTechnologies");

            migrationBuilder.DropColumn(
                name: "AccumulatedCountryId",
                table: "CountryEconomy");

            migrationBuilder.DropColumn(
                name: "AccumulatedSaveId",
                table: "CountryEconomy");

            migrationBuilder.DropColumn(
                name: "AccumulatedType",
                table: "CountryEconomy");

            migrationBuilder.DropColumn(
                name: "SpentCountryId",
                table: "CountryEconomy");

            migrationBuilder.DropColumn(
                name: "SpentSaveId",
                table: "CountryEconomy");

            migrationBuilder.DropColumn(
                name: "SpentType",
                table: "CountryEconomy");

            migrationBuilder.AddColumn<int>(
                name: "CountryTechnologiesCountryId",
                table: "CountryTechnology",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryTechnologiesSaveId",
                table: "CountryTechnology",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryEconomyCountryId",
                table: "CountryEconomyTelemetry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryEconomySaveId",
                table: "CountryEconomyTelemetry",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LastMonthIncome",
                table: "CountryEconomy",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_CountryTechnology_CountryTechnologiesSaveId_CountryTechnolog~",
                table: "CountryTechnology",
                columns: new[] { "CountryTechnologiesSaveId", "CountryTechnologiesCountryId" });

            migrationBuilder.CreateIndex(
                name: "IX_CountryEconomyTelemetry_CountryEconomySaveId_CountryEconomyC~",
                table: "CountryEconomyTelemetry",
                columns: new[] { "CountryEconomySaveId", "CountryEconomyCountryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CountryEconomyTelemetry_CountryEconomy_CountryEconomySaveId_~",
                table: "CountryEconomyTelemetry",
                columns: new[] { "CountryEconomySaveId", "CountryEconomyCountryId" },
                principalTable: "CountryEconomy",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryTechnology_CountryTechnologies_CountryTechnologiesSav~",
                table: "CountryTechnology",
                columns: new[] { "CountryTechnologiesSaveId", "CountryTechnologiesCountryId" },
                principalTable: "CountryTechnologies",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryEconomyTelemetry_CountryEconomy_CountryEconomySaveId_~",
                table: "CountryEconomyTelemetry");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryTechnology_CountryTechnologies_CountryTechnologiesSav~",
                table: "CountryTechnology");

            migrationBuilder.DropIndex(
                name: "IX_CountryTechnology_CountryTechnologiesSaveId_CountryTechnolog~",
                table: "CountryTechnology");

            migrationBuilder.DropIndex(
                name: "IX_CountryEconomyTelemetry_CountryEconomySaveId_CountryEconomyC~",
                table: "CountryEconomyTelemetry");

            migrationBuilder.DropColumn(
                name: "CountryTechnologiesCountryId",
                table: "CountryTechnology");

            migrationBuilder.DropColumn(
                name: "CountryTechnologiesSaveId",
                table: "CountryTechnology");

            migrationBuilder.DropColumn(
                name: "CountryEconomyCountryId",
                table: "CountryEconomyTelemetry");

            migrationBuilder.DropColumn(
                name: "CountryEconomySaveId",
                table: "CountryEconomyTelemetry");

            migrationBuilder.DropColumn(
                name: "LastMonthIncome",
                table: "CountryEconomy");

            migrationBuilder.AddColumn<int>(
                name: "CivicCountryId",
                table: "CountryTechnologies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CivicSaveId",
                table: "CountryTechnologies",
                type: "varchar(50) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CivicType",
                table: "CountryTechnologies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MilitaryCountryId",
                table: "CountryTechnologies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MilitarySaveId",
                table: "CountryTechnologies",
                type: "varchar(50) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MilitaryType",
                table: "CountryTechnologies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OratoryCountryId",
                table: "CountryTechnologies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OratorySaveId",
                table: "CountryTechnologies",
                type: "varchar(50) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OratoryType",
                table: "CountryTechnologies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReligiousCountryId",
                table: "CountryTechnologies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReligiousSaveId",
                table: "CountryTechnologies",
                type: "varchar(50) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReligiousType",
                table: "CountryTechnologies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccumulatedCountryId",
                table: "CountryEconomy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccumulatedSaveId",
                table: "CountryEconomy",
                type: "varchar(50) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccumulatedType",
                table: "CountryEconomy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpentCountryId",
                table: "CountryEconomy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpentSaveId",
                table: "CountryEconomy",
                type: "varchar(50) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpentType",
                table: "CountryEconomy",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CountryEconomy_AccumulatedSaveId_AccumulatedCountryId_Accumu~",
                table: "CountryEconomy",
                columns: new[] { "AccumulatedSaveId", "AccumulatedCountryId", "AccumulatedType" });

            migrationBuilder.CreateIndex(
                name: "IX_CountryEconomy_SpentSaveId_SpentCountryId_SpentType",
                table: "CountryEconomy",
                columns: new[] { "SpentSaveId", "SpentCountryId", "SpentType" });

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
                name: "FK_CountryEconomyTelemetry_CountryEconomy_SaveId_CountryId",
                table: "CountryEconomyTelemetry",
                columns: new[] { "SaveId", "CountryId" },
                principalTable: "CountryEconomy",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Cascade);

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
