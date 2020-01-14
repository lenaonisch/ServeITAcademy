using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgencyHelper.Migrations
{
    public partial class SqlGenerator4Route : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Routes",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Routes",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValueSql: "1");
        }
    }
}
