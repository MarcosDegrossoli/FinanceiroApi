using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financeiro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    IdBanco = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeBanco = table.Column<string>(type: "text", nullable: false),
                    CodigoBanco = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.IdBanco);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeCategoria = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    IdTransacao = table.Column<Guid>(type: "uuid", nullable: false),
                    Comentario = table.Column<string>(type: "text", nullable: false),
                    IdCategoria = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.IdTransacao);
                    table.ForeignKey(
                        name: "FK_Transacoes_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    IdConta = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroConta = table.Column<string>(type: "text", nullable: false),
                    IdBanco = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.IdConta);
                    table.ForeignKey(
                        name: "FK_Contas_Bancos_IdBanco",
                        column: x => x.IdBanco,
                        principalTable: "Bancos",
                        principalColumn: "IdBanco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    IdLancamento = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    IdConta = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.IdLancamento);
                    table.ForeignKey(
                        name: "FK_Lancamentos_Contas_IdConta",
                        column: x => x.IdConta,
                        principalTable: "Contas",
                        principalColumn: "IdConta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LancamentosXtransacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdLancamento = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTransacao = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentosXtransacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentosXtransacoes_Lancamentos_IdLancamento",
                        column: x => x.IdLancamento,
                        principalTable: "Lancamentos",
                        principalColumn: "IdLancamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LancamentosXtransacoes_Transacoes_IdTransacao",
                        column: x => x.IdTransacao,
                        principalTable: "Transacoes",
                        principalColumn: "IdTransacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_IdBanco",
                table: "Contas",
                column: "IdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_IdUsuario",
                table: "Contas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_IdConta",
                table: "Lancamentos",
                column: "IdConta");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosXtransacoes_IdLancamento",
                table: "LancamentosXtransacoes",
                column: "IdLancamento");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosXtransacoes_IdTransacao",
                table: "LancamentosXtransacoes",
                column: "IdTransacao");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_IdCategoria",
                table: "Transacoes",
                column: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LancamentosXtransacoes");

            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Bancos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
