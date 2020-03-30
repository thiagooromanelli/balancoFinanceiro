using Microsoft.EntityFrameworkCore.Migrations;

namespace BalancoFinanceiro.Migrations
{
    public partial class UpdatedBalancoFinanceiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Lancamentos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Date",
                table: "Lancamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
