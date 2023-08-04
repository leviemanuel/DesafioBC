using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteBC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Entidades",
                columns: table => new
                {
                    idEntidade = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlPessoaFisica = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlAtivo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades", x => x.idEntidade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    idLancamento = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DtVencimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DtPagamento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VlLancamento = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    VlDesconto = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    VlJurosMora = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    VlEncargos = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    VlTotal = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FlCredito = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CodBarras = table.Column<string>(type: "varchar(48)", maxLength: 48, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InstituicaoEmissora = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Agencia = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContaCorrente = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntidadeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.idLancamento);
                    table.ForeignKey(
                        name: "FK_Lancamentos_Entidades_EntidadeId",
                        column: x => x.EntidadeId,
                        principalTable: "Entidades",
                        principalColumn: "idEntidade",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_EntidadeId",
                table: "Lancamentos",
                column: "EntidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "Entidades");
        }
    }
}
