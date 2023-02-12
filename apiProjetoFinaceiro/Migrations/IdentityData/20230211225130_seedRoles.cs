using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiProjetoFinaceiro.Migrations.IdentityData
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "niveis_usuario",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[] { "90EE101C-63B2-4F5C-B0DF-C198DDCB8A9E", "2b03177d-97ad-4349-bd87-f722cc57bd90", "GRATUITO", "GRATUITO" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[] { "E2AFAC93-D1E2-4A09-A860-E38F735519F1", "e6ae73ee-1c69-4454-b750-f125ae9c5248", "VIP", "VIP" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "90EE101C-63B2-4F5C-B0DF-C198DDCB8A9E");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "E2AFAC93-D1E2-4A09-A860-E38F735519F1");

            migrationBuilder.AddColumn<int>(
                name: "niveis_usuario",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
