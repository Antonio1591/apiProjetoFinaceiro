using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiProjetoFinaceiro.Migrations
{
    public partial class newBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bairro",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    situacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bairro", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cep = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    situacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cidade", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_movimentacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo_operacao = table.Column<int>(type: "int", nullable: false),
                    tipo_descriscao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    situacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipo_movimentacao", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cidade_id = table.Column<int>(type: "int", nullable: false),
                    bairro_id = table.Column<int>(type: "int", nullable: false),
                    cpf = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_nascimento = table.Column<DateTime>(type: "Date", nullable: false),
                    situacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario", x => x.id);
                    table.ForeignKey(
                        name: "fk_usuario_bairro_bairro_id",
                        column: x => x.bairro_id,
                        principalTable: "bairro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_usuario_cidade_cidade_id",
                        column: x => x.cidade_id,
                        principalTable: "cidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movimentacao_finaceira",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    datamovimentacaolancamento = table.Column<DateTime>(type: "Datetime(2)", nullable: false),
                    datamovimentacao_entrada = table.Column<DateTime>(type: "Datetime(2)", nullable: false),
                    valor_movimentacao = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    tipo_movimentacao_id = table.Column<int>(type: "int", nullable: false),
                    situacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_movimentacao_finaceira", x => x.id);
                    table.ForeignKey(
                        name: "fk_movimentacao_finaceira_tipo_movimentacao_tipo_movimentacao_id",
                        column: x => x.tipo_movimentacao_id,
                        principalTable: "tipo_movimentacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_movimentacao_finaceira_usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_movimentacao_finaceira_tipo_movimentacao_id",
                table: "movimentacao_finaceira",
                column: "tipo_movimentacao_id");

            migrationBuilder.CreateIndex(
                name: "ix_movimentacao_finaceira_usuario_id",
                table: "movimentacao_finaceira",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "ix_usuario_bairro_id",
                table: "usuario",
                column: "bairro_id");

            migrationBuilder.CreateIndex(
                name: "ix_usuario_cidade_id",
                table: "usuario",
                column: "cidade_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimentacao_finaceira");

            migrationBuilder.DropTable(
                name: "tipo_movimentacao");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "bairro");

            migrationBuilder.DropTable(
                name: "cidade");
        }
    }
}
