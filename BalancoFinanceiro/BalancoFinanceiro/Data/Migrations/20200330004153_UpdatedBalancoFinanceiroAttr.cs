using Microsoft.EntityFrameworkCore.Migrations;

namespace BalancoFinanceiro.Migrations
{
    public partial class UpdatedBalancoFinanceiroAttr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Lancamentos",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Lancamentos",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Lancamentos",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Lancamentos",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lancamentos",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "value",
                table: "Lancamentos",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Lancamentos",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Lancamentos",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Lancamentos",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Lancamentos",
                newName: "Id");
        }
    }
}
