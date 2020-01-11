using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgencyHelper.Migrations
{
    public partial class RouteIdChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaysInRoutes_Routes_RouteId",
                table: "DaysInRoutes");

            migrationBuilder.AlterColumn<long>(
                name: "RouteId",
                table: "DaysInRoutes",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DaysInRoutes_Routes_RouteId",
                table: "DaysInRoutes",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaysInRoutes_Routes_RouteId",
                table: "DaysInRoutes");

            migrationBuilder.AlterColumn<long>(
                name: "RouteId",
                table: "DaysInRoutes",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_DaysInRoutes_Routes_RouteId",
                table: "DaysInRoutes",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
