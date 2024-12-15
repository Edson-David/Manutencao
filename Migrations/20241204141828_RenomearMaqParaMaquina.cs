using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manutencao.Migrations
{
    /// <inheritdoc />
    public partial class RenomearMaqParaMaquina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Maq",
                table: "Reparos",
                newName: "Maquina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Maquina",
                table: "Reparos",
                newName: "Maq");
        }
    }
}
