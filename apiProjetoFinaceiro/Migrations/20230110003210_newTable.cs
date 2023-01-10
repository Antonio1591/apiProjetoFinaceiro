using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiProjetoFinaceiro.Migrations
{
    public partial class newTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo_movimentacao",
                table: "movimentacao_finaceira");

            migrationBuilder.DropColumn(
                name: "tipo_movimentacao_descricao",
                table: "movimentacao_finaceira");

            migrationBuilder.AddColumn<int>(
                name: "tipo_movimentacaoid",
                table: "movimentacao_finaceira",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tipo_movimentacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo_operacao = table.Column<int>(type: "int", nullable: false),
                    tipo_descriscao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    situacao_enum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipo_movimentacao", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_movimentacao_finaceira_tipo_movimentacaoid",
                table: "movimentacao_finaceira",
                column: "tipo_movimentacaoid");

            migrationBuilder.AddForeignKey(
                name: "fk_movimentacao_finaceira_tipo_movimentacao_tipo_movimentacaoid",
                table: "movimentacao_finaceira",
                column: "tipo_movimentacaoid",
                principalTable: "tipo_movimentacao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_movimentacao_finaceira_tipo_movimentacao_tipo_movimentacaoid",
                table: "movimentacao_finaceira");

            migrationBuilder.DropTable(
                name: "tipo_movimentacao");

            migrationBuilder.DropIndex(
                name: "ix_movimentacao_finaceira_tipo_movimentacaoid",
                table: "movimentacao_finaceira");

            migrationBuilder.DropColumn(
                name: "tipo_movimentacaoid",
                table: "movimentacao_finaceira");

            migrationBuilder.AddColumn<string>(
                name: "tipo_movimentacao",
                table: "movimentacao_finaceira",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tipo_movimentacao_descricao",
                table: "movimentacao_finaceira",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
