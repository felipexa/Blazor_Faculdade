using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_Piloto.Server.Migrations
{
    public partial class MigrationChefia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Chefias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Chefias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
