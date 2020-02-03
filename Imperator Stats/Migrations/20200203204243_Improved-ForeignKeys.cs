using Microsoft.EntityFrameworkCore.Migrations;

namespace ImperatorStats.Migrations
{
    public partial class ImprovedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_SaveId_ControllerId",
                table: "Provinces");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_SaveId_OwnerId",
                table: "Provinces");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_SaveId_PreviousControllerId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "Culture",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "OriginalCulture",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "OriginalReligion",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Provinces");

            migrationBuilder.AlterColumn<int>(
                name: "PreviousControllerId",
                table: "Provinces",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Provinces",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ControllerId",
                table: "Provinces",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CultureId",
                table: "Provinces",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalCultureId",
                table: "Provinces",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalReligionId",
                table: "Provinces",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReligionId",
                table: "Provinces",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CultureId",
                table: "Provinces",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_OriginalCultureId",
                table: "Provinces",
                column: "OriginalCultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_OriginalReligionId",
                table: "Provinces",
                column: "OriginalReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_ReligionId",
                table: "Provinces",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Cultures_CultureId",
                table: "Provinces",
                column: "CultureId",
                principalTable: "Cultures",
                principalColumn: "CultureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Cultures_OriginalCultureId",
                table: "Provinces",
                column: "OriginalCultureId",
                principalTable: "Cultures",
                principalColumn: "CultureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Religions_OriginalReligionId",
                table: "Provinces",
                column: "OriginalReligionId",
                principalTable: "Religions",
                principalColumn: "ReligionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Religions_ReligionId",
                table: "Provinces",
                column: "ReligionId",
                principalTable: "Religions",
                principalColumn: "ReligionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_SaveId_ControllerId",
                table: "Provinces",
                columns: new[] { "SaveId", "ControllerId" },
                principalTable: "Countries",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_SaveId_OwnerId",
                table: "Provinces",
                columns: new[] { "SaveId", "OwnerId" },
                principalTable: "Countries",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_SaveId_PreviousControllerId",
                table: "Provinces",
                columns: new[] { "SaveId", "PreviousControllerId" },
                principalTable: "Countries",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Cultures_CultureId",
                table: "Provinces");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Cultures_OriginalCultureId",
                table: "Provinces");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Religions_OriginalReligionId",
                table: "Provinces");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Religions_ReligionId",
                table: "Provinces");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_SaveId_ControllerId",
                table: "Provinces");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_SaveId_OwnerId",
                table: "Provinces");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_SaveId_PreviousControllerId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_CultureId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_OriginalCultureId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_OriginalReligionId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_ReligionId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "CultureId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "OriginalCultureId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "OriginalReligionId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "Provinces");

            migrationBuilder.AlterColumn<int>(
                name: "PreviousControllerId",
                table: "Provinces",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Provinces",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ControllerId",
                table: "Provinces",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Culture",
                table: "Provinces",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalCulture",
                table: "Provinces",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalReligion",
                table: "Provinces",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "Provinces",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_SaveId_ControllerId",
                table: "Provinces",
                columns: new[] { "SaveId", "ControllerId" },
                principalTable: "Countries",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_SaveId_OwnerId",
                table: "Provinces",
                columns: new[] { "SaveId", "OwnerId" },
                principalTable: "Countries",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_SaveId_PreviousControllerId",
                table: "Provinces",
                columns: new[] { "SaveId", "PreviousControllerId" },
                principalTable: "Countries",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
