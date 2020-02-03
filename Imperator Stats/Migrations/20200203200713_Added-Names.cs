using Microsoft.EntityFrameworkCore.Migrations;

namespace ImperatorStats.Migrations
{
    public partial class AddedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Culture",
                table: "Pops");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Pops");

            migrationBuilder.DropColumn(
                name: "MainReligion",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "PrimaryCulture",
                table: "Countries");

            migrationBuilder.AddColumn<string>(
                name: "CultureId",
                table: "Pops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReligionId",
                table: "Pops",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Countries",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainReligionId",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryCultureId",
                table: "Countries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CountryNames",
                columns: table => new
                {
                    CountryTag = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryNames", x => x.CountryTag);
                });

            migrationBuilder.CreateTable(
                name: "Cultures",
                columns: table => new
                {
                    CultureId = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultures", x => x.CultureId);
                });

            migrationBuilder.CreateTable(
                name: "ProvinceNames",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceNames", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    ReligionId = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.ReligionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pops_CultureId",
                table: "Pops",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Pops_ReligionId",
                table: "Pops",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_MainReligionId",
                table: "Countries",
                column: "MainReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_PrimaryCultureId",
                table: "Countries",
                column: "PrimaryCultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Tag",
                table: "Countries",
                column: "Tag");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Religions_MainReligionId",
                table: "Countries",
                column: "MainReligionId",
                principalTable: "Religions",
                principalColumn: "ReligionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Cultures_PrimaryCultureId",
                table: "Countries",
                column: "PrimaryCultureId",
                principalTable: "Cultures",
                principalColumn: "CultureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_CountryNames_Tag",
                table: "Countries",
                column: "Tag",
                principalTable: "CountryNames",
                principalColumn: "CountryTag",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pops_Cultures_CultureId",
                table: "Pops",
                column: "CultureId",
                principalTable: "Cultures",
                principalColumn: "CultureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pops_Religions_ReligionId",
                table: "Pops",
                column: "ReligionId",
                principalTable: "Religions",
                principalColumn: "ReligionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Religions_MainReligionId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Cultures_PrimaryCultureId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_CountryNames_Tag",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Pops_Cultures_CultureId",
                table: "Pops");

            migrationBuilder.DropForeignKey(
                name: "FK_Pops_Religions_ReligionId",
                table: "Pops");

            migrationBuilder.DropTable(
                name: "CountryNames");

            migrationBuilder.DropTable(
                name: "Cultures");

            migrationBuilder.DropTable(
                name: "ProvinceNames");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropIndex(
                name: "IX_Pops_CultureId",
                table: "Pops");

            migrationBuilder.DropIndex(
                name: "IX_Pops_ReligionId",
                table: "Pops");

            migrationBuilder.DropIndex(
                name: "IX_Countries_MainReligionId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_PrimaryCultureId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Tag",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CultureId",
                table: "Pops");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "Pops");

            migrationBuilder.DropColumn(
                name: "MainReligionId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "PrimaryCultureId",
                table: "Countries");

            migrationBuilder.AddColumn<string>(
                name: "Culture",
                table: "Pops",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "Pops",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Countries",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainReligion",
                table: "Countries",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryCulture",
                table: "Countries",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
