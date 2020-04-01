using Microsoft.EntityFrameworkCore.Migrations;

namespace BalancoFinanceiro.Migrations
{
    public partial class DeletedBalancoDiarioDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalancosDiarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalancosDiarios",
                columns: table => new
                {
                    date = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    balance = table.Column<double>(type: "float", nullable: false),
                    totValCredit = table.Column<double>(type: "float", nullable: false),
                    totValDebit = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalancosDiarios", x => x.date);
                });
        }
    }
}
