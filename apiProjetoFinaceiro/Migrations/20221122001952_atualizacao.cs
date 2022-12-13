using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiProjetoFinaceiro.Migrations
{
    public partial class atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cidade_bairro_bairroId",
                table: "cidade");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_cidade_cidadeId",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_cidade_bairroId",
                table: "cidade");

            migrationBuilder.DropColumn(
                name: "bairroId",
                table: "cidade");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "bairro");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "bairro");

            migrationBuilder.RenameColumn(
                name: "senha",
                table: "usuario",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "usuario",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "cidadeId",
                table: "usuario",
                newName: "CidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_usuario_cidadeId",
                table: "usuario",
                newName: "IX_usuario_CidadeId");

            migrationBuilder.RenameColumn(
                name: "cep",
                table: "cidade",
                newName: "Cep");

            migrationBuilder.RenameColumn(
                name: "Logradouro",
                table: "bairro",
                newName: "Situacao");

            migrationBuilder.AddColumn<int>(
                name: "BairroId",
                table: "usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "usuario",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "usuario",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_usuario_BairroId",
                table: "usuario",
                column: "BairroId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_bairro_BairroId",
                table: "usuario",
                column: "BairroId",
                principalTable: "bairro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_cidade_CidadeId",
                table: "usuario",
                column: "CidadeId",
                principalTable: "cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_bairro_BairroId",
                table: "usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_cidade_CidadeId",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_BairroId",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "BairroId",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "usuario");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "usuario",
                newName: "senha");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "usuario",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "CidadeId",
                table: "usuario",
                newName: "cidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_usuario_CidadeId",
                table: "usuario",
                newName: "IX_usuario_cidadeId");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "cidade",
                newName: "cep");

            migrationBuilder.RenameColumn(
                name: "Situacao",
                table: "bairro",
                newName: "Logradouro");

            migrationBuilder.AddColumn<int>(
                name: "bairroId",
                table: "cidade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "bairro",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "bairro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cidade_bairroId",
                table: "cidade",
                column: "bairroId");

            migrationBuilder.AddForeignKey(
                name: "FK_cidade_bairro_bairroId",
                table: "cidade",
                column: "bairroId",
                principalTable: "bairro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_cidade_cidadeId",
                table: "usuario",
                column: "cidadeId",
                principalTable: "cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
