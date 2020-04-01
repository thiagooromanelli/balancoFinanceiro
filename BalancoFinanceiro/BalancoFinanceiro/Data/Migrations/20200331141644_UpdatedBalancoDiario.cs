using Microsoft.EntityFrameworkCore.Migrations;

namespace BalancoFinanceiro.Migrations
{
    public partial class UpdatedBalancoDiario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BalancosDiarios",
                table: "BalancosDiarios");

            migrationBuilder.DropColumn(
                name: "id",
                table: "BalancosDiarios");

            migrationBuilder.AlterColumn<string>(
                name: "date",
                table: "BalancosDiarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BalancosDiarios",
                table: "BalancosDiarios",
                column: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BalancosDiarios",
                table: "BalancosDiarios");

            migrationBuilder.AlterColumn<string>(
                name: "date",
                table: "BalancosDiarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "BalancosDiarios",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BalancosDiarios",
                table: "BalancosDiarios",
                column: "id");
        }
    }
}
