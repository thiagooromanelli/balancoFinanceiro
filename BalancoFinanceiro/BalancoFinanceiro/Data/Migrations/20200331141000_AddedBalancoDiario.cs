using Microsoft.EntityFrameworkCore.Migrations;

namespace BalancoFinanceiro.Migrations
{
    public partial class AddedBalancoDiario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalancosDiarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<string>(nullable: false),
                    totValCredit = table.Column<double>(nullable: false),
                    totValDebit = table.Column<double>(nullable: false),
                    balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalancosDiarios", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalancosDiarios");
        }
    }
}
