using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoMotors.Migrations
{
    /// <inheritdoc />
    public partial class migracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Portas",
                table: "Veiculos");

            migrationBuilder.CreateTable(
                name: "ChatIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatIA_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerguntaRespostaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatIAModelId = table.Column<int>(type: "int", nullable: false),
                    Pergunta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerguntaRespostaModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerguntaRespostaModel_ChatIA_ChatIAModelId",
                        column: x => x.ChatIAModelId,
                        principalTable: "ChatIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatIA_UserId",
                table: "ChatIA",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PerguntaRespostaModel_ChatIAModelId",
                table: "PerguntaRespostaModel",
                column: "ChatIAModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerguntaRespostaModel");

            migrationBuilder.DropTable(
                name: "ChatIA");

            migrationBuilder.AddColumn<string>(
                name: "Portas",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
