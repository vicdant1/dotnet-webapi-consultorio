using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    public partial class RemovendoNoem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Agendamentos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Agendamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
