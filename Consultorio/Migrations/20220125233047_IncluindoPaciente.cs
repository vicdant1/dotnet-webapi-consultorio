using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    public partial class IncluindoPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Filhos = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_PacienteId",
                table: "Agendamentos",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Paciente_PacienteId",
                table: "Agendamentos",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Paciente_PacienteId",
                table: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_PacienteId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Agendamentos");
        }
    }
}
