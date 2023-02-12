using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiProjetoFinaceiro.Migrations
{
    public partial class atttData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "datamovimentacaolancamento",
                table: "movimentacao_finaceira",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime(2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datamovimentacao_entrada",
                table: "movimentacao_finaceira",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime(2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "datamovimentacaolancamento",
                table: "movimentacao_finaceira",
                type: "Datetime(2)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datamovimentacao_entrada",
                table: "movimentacao_finaceira",
                type: "Datetime(2)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
