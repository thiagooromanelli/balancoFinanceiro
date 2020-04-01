using Microsoft.EntityFrameworkCore.Migrations;

namespace BalancoFinanceiro.Migrations
{
    public partial class DeletedBalancoDia : Migration
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
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    balance = table.Column<double>(type: "float", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totValCredit = table.Column<double>(type: "float", nullable: false),
                    totValDebit = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalancosDiarios", x => x.id);
                });
        }
    }
}
