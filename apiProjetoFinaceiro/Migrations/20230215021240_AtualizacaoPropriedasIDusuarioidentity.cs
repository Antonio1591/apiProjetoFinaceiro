using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiProjetoFinaceiro.Migrations
{
    public partial class AtualizacaoPropriedasIDusuarioidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email_usuario_identity",
                table: "movimentacao_finaceira");

            migrationBuilder.AddColumn<Guid>(
                name: "id_usuario_identity",
                table: "tipo_movimentacao",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "id_usuario_identity",
                table: "movimentacao_finaceira",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_usuario_identity",
                table: "tipo_movimentacao");

            migrationBuilder.DropColumn(
                name: "id_usuario_identity",
                table: "movimentacao_finaceira");

            migrationBuilder.AddColumn<string>(
                name: "email_usuario_identity",
                table: "movimentacao_finaceira",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
