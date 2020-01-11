using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgencyHelper.Migrations
{
    public partial class IsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Routes",
                nullable: true,
                defaultValueSql: "1");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "DaysInRoutes",
                nullable: true,
                defaultValueSql: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "DaysInRoutes");
        }
    }
}
