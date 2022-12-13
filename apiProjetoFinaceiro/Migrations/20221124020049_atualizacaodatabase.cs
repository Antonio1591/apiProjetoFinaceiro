using Microsoft.EntityFrameworkCore.Migrations;



#nullable disable

namespace apiProjetoFinaceiro.Migrations
{
    public partial class atualizacaodatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Situacao",
                table: "usuario",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Situacao",
                table: "cidade",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "cidade");
        }
    }
}
