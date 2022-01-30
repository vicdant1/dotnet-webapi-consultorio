using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    public partial class fixingConfigureMethodReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas");

            migrationBuilder.RenameTable(
                name: "Consultas",
                newName: "tb_consulta");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_consulta",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_consulta",
                table: "tb_consulta",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_consulta",
                table: "tb_consulta");

            migrationBuilder.RenameTable(
                name: "tb_consulta",
                newName: "Consultas");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Consultas",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas",
                column: "Id");
        }
    }
}
