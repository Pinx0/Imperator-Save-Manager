using Microsoft.EntityFrameworkCore.Migrations;

namespace ImperatorStats.Migrations
{
    public partial class AddedInventions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalInventions",
                table: "Countries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalInventions",
                table: "Countries");
        }
    }
}
