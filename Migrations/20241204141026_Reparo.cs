using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manutencao.Migrations
{
    /// <inheritdoc />
    public partial class Reparo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reparos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maq = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Problema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resolvido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reparos");
        }
    }
}
