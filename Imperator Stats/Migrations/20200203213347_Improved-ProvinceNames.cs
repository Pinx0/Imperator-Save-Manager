using Microsoft.EntityFrameworkCore.Migrations;

namespace ImperatorStats.Migrations
{
    public partial class ImprovedProvinceNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pops_Provinces_SaveId_ProvinceId",
                table: "Pops");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceId",
                table: "Pops",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_ProvinceId",
                table: "Provinces",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pops_Provinces_SaveId_ProvinceId",
                table: "Pops",
                columns: new[] { "SaveId", "ProvinceId" },
                principalTable: "Provinces",
                principalColumns: new[] { "SaveId", "ProvinceId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_ProvinceNames_ProvinceId",
                table: "Provinces",
                column: "ProvinceId",
                principalTable: "ProvinceNames",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pops_Provinces_SaveId_ProvinceId",
                table: "Pops");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_ProvinceNames_ProvinceId",
                table: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_ProvinceId",
                table: "Provinces");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceId",
                table: "Pops",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pops_Provinces_SaveId_ProvinceId",
                table: "Pops",
                columns: new[] { "SaveId", "ProvinceId" },
                principalTable: "Provinces",
                principalColumns: new[] { "SaveId", "ProvinceId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
