using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoMotors.Migrations
{
    /// <inheritdoc />
    public partial class adss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cilindradas",
                table: "Veiculos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cilindradas",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
