using Microsoft.EntityFrameworkCore.Migrations;

namespace ImperatorStats.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_CountryEconomyTelemetry_CountryEconomy_SaveId_CountryId",
                table: "CountryEconomyTelemetry",
                columns: new[] { "SaveId", "CountryId" },
                principalTable: "CountryEconomy",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryTechnology_CountryTechnologies_SaveId_CountryId",
                table: "CountryTechnology",
                columns: new[] { "SaveId", "CountryId" },
                principalTable: "CountryTechnologies",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryEconomyTelemetry_CountryEconomy_SaveId_CountryId",
                table: "CountryEconomyTelemetry");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryTechnology_CountryTechnologies_SaveId_CountryId",
                table: "CountryTechnology");

            migrationBuilder.AddColumn<int>(
                name: "CountryTechnologiesCountryId",
                table: "CountryTechnology",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryTechnologiesSaveId",
                table: "CountryTechnology",
                type: "varchar(50) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryEconomyCountryId",
                table: "CountryEconomyTelemetry",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryEconomySaveId",
                table: "CountryEconomyTelemetry",
                type: "varchar(50) CHARACTER SET utf8mb4",
                nullable: true);

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
    }
}
