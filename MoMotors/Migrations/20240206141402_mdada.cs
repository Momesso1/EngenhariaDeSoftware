using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoMotors.Migrations
{
    /// <inheritdoc />
    public partial class mdada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Veiculos");
        }
    }
}
