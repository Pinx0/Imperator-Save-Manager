using Microsoft.EntityFrameworkCore.Migrations;

namespace ImperatorStats.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Culture",
                table: "Families",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Families",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Prestige",
                table: "Families",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "CountryType",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LastMonthExpense",
                table: "Countries",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MainReligion",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryCulture",
                table: "Countries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Families_SaveId_OwnerId",
                table: "Families",
                columns: new[] { "SaveId", "OwnerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Families_Countries_SaveId_OwnerId",
                table: "Families",
                columns: new[] { "SaveId", "OwnerId" },
                principalTable: "Countries",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_Countries_SaveId_OwnerId",
                table: "Families");

            migrationBuilder.DropIndex(
                name: "IX_Families_SaveId_OwnerId",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "Culture",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "Prestige",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "CountryType",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "LastMonthExpense",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "MainReligion",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "PrimaryCulture",
                table: "Countries");
        }
    }
}
