using Microsoft.EntityFrameworkCore.Migrations;

namespace ImperatorStats.Migrations
{
    public partial class ImprovedKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pops_Provinces_ProvinceSaveId_ProvinceId",
                table: "Pops");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_ControllerSaveId_ControllerCountryId",
                table: "Provinces");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_OwnerSaveId_OwnerCountryId",
                table: "Provinces");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Countries_PreviousControllerSaveId_PreviousControl~",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_ControllerSaveId_ControllerCountryId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_OwnerSaveId_OwnerCountryId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_PreviousControllerSaveId_PreviousControllerCountry~",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Pops_ProvinceSaveId_ProvinceId",
                table: "Pops");

            migrationBuilder.DropColumn(
                name: "ControllerCountryId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "ControllerSaveId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "OwnerCountryId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "OwnerSaveId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "PreviousControllerCountryId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "PreviousControllerSaveId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "ProvinceSaveId",
                table: "Pops");

            migrationBuilder.AddColumn<int>(
                name: "ControllerId",
                table: "Provinces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Provinces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreviousControllerId",
                table: "Provinces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceId",
                table: "Pops",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_SaveId_ControllerId",
                table: "Provinces",
                columns: new[] { "SaveId", "ControllerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_SaveId_OwnerId",
                table: "Provinces",
                columns: new[] { "SaveId", "OwnerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_SaveId_PreviousControllerId",
                table: "Provinces",
                columns: new[] { "SaveId", "PreviousControllerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Pops_SaveId_ProvinceId",
                table: "Pops",
                columns: new[] { "SaveId", "ProvinceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pops_Provinces_SaveId_ProvinceId",
                table: "Pops",
                columns: new[] { "SaveId", "ProvinceId" },
                principalTable: "Provinces",
                principalColumns: new[] { "SaveId", "ProvinceId" },
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pops_Provinces_SaveId_ProvinceId",
                table: "Pops");

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
                name: "IX_Provinces_SaveId_ControllerId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_SaveId_OwnerId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_SaveId_PreviousControllerId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Pops_SaveId_ProvinceId",
                table: "Pops");

            migrationBuilder.DropColumn(
                name: "ControllerId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "PreviousControllerId",
                table: "Provinces");

            migrationBuilder.AddColumn<int>(
                name: "ControllerCountryId",
                table: "Provinces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ControllerSaveId",
                table: "Provinces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerCountryId",
                table: "Provinces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerSaveId",
                table: "Provinces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreviousControllerCountryId",
                table: "Provinces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreviousControllerSaveId",
                table: "Provinces",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceId",
                table: "Pops",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProvinceSaveId",
                table: "Pops",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Pops_ProvinceSaveId_ProvinceId",
                table: "Pops",
                columns: new[] { "ProvinceSaveId", "ProvinceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pops_Provinces_ProvinceSaveId_ProvinceId",
                table: "Pops",
                columns: new[] { "ProvinceSaveId", "ProvinceId" },
                principalTable: "Provinces",
                principalColumns: new[] { "SaveId", "ProvinceId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_ControllerSaveId_ControllerCountryId",
                table: "Provinces",
                columns: new[] { "ControllerSaveId", "ControllerCountryId" },
                principalTable: "Countries",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_OwnerSaveId_OwnerCountryId",
                table: "Provinces",
                columns: new[] { "OwnerSaveId", "OwnerCountryId" },
                principalTable: "Countries",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Countries_PreviousControllerSaveId_PreviousControl~",
                table: "Provinces",
                columns: new[] { "PreviousControllerSaveId", "PreviousControllerCountryId" },
                principalTable: "Countries",
                principalColumns: new[] { "SaveId", "CountryId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
