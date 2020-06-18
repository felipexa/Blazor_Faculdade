using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_Piloto.Server.Migrations
{
    public partial class nomeCurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeCurso",
                table: "Alunos",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeCurso",
                table: "Alunos");
        }
    }
}
