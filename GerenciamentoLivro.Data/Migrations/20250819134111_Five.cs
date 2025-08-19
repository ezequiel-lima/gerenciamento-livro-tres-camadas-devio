using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoLivro.Data.Migrations
{
    /// <inheritdoc />
    public partial class Five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeEmprestimo",
                table: "Emprestimos",
                newName: "DataEmprestimo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataEmprestimo",
                table: "Emprestimos",
                newName: "DataDeEmprestimo");
        }
    }
}
