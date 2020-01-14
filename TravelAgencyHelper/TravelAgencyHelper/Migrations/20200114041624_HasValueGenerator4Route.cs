using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgencyHelper.Migrations
{
    public partial class HasValueGenerator4Route : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Routes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Routes",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<int>(
                name: "Deposit",
                table: "Routes",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Routes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Routes",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Deposit",
                table: "Routes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
