using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InserindoDadosNaTabelaDeFilmes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Filmes", ["Titulo", "Genero", "Duracao"], ["Guerra dos Mundos", "Ficção Científica", 116]);
            migrationBuilder.InsertData("Filmes", ["Titulo", "Genero", "Duracao"], ["Invocação do Mal", "Terror", 112]);
            migrationBuilder.InsertData("Filmes", ["Titulo", "Genero", "Duracao"], ["Avatar", "Aventura", 197]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Filmes");
        }
    }
}
