using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_Piloto.Server.Migrations
{
    public partial class RemoveNomeCurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Cursos_CursoId_Curso",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_CursoId_Curso",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "CursoId_Curso",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "CursosId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "NomeCurso",
                table: "Alunos");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Alunos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Alunos",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Alunos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Alunos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Cursos_CursoId",
                table: "Alunos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id_Curso",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Cursos_CursoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Alunos");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Alunos",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "CursoId_Curso",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CursosId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomeCurso",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_CursoId_Curso",
                table: "Alunos",
                column: "CursoId_Curso");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Cursos_CursoId_Curso",
                table: "Alunos",
                column: "CursoId_Curso",
                principalTable: "Cursos",
                principalColumn: "Id_Curso",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
