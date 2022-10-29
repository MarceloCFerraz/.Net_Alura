using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Pacientes.Migrations
{
    public partial class Adicionadocampodegordura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gordura",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gordura",
                table: "Pacientes");
        }
    }
}
