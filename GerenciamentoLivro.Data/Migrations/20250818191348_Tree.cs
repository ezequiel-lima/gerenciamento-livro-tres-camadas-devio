using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoLivro.Data.Migrations
{
    /// <inheritdoc />
    public partial class Tree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeDevolucao",
                table: "Emprestimos",
                newName: "DataDevolucaoPrevista");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDevolucaoEfetiva",
                table: "Emprestimos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDevolucaoEfetiva",
                table: "Emprestimos");

            migrationBuilder.RenameColumn(
                name: "DataDevolucaoPrevista",
                table: "Emprestimos",
                newName: "DataDeDevolucao");
        }
    }
}
