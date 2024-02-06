using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoMotors.Migrations
{
    /// <inheritdoc />
    public partial class dadadadkada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Veiculos",
                newName: "Condicao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Condicao",
                table: "Veiculos",
                newName: "Titulo");
        }
    }
}
