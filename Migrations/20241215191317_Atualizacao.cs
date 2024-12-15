using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manutencao.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resolvido",
                table: "Reparos");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Reparos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reparos");

            migrationBuilder.AddColumn<bool>(
                name: "Resolvido",
                table: "Reparos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
