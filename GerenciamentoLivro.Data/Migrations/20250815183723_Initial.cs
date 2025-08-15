using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoLivro.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Autor = table.Column<string>(type: "varchar(250)", nullable: false),
                    Isbn = table.Column<string>(type: "varchar(17)", nullable: false),
                    DataDePublicacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLivro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataDeEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Livros_IdLivro",
                        column: x => x.IdLivro,
                        principalTable: "Livros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Emprestimos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_IdLivro",
                table: "Emprestimos",
                column: "IdLivro");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_IdUsuario",
                table: "Emprestimos",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimos");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
