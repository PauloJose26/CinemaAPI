using CinemaAPI.Models;
using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Data.Dtos;

public class UpdateFilmeDto
{
    public string? Titulo { get; set; }
    [MaxLength(50, ErrorMessage = "O Genero não pode exceder 50 caracteres")]
    public string? Genero { get; set; }
    [Range(70, 600, ErrorMessage = "A Duração do filme deve ter entre 70 e 600 minutos")]
    public int? Duracao { get; set; }

    public void AtualizarFilme(Filme filme)
    {
        filme.Titulo = (!string.IsNullOrWhiteSpace(this.Titulo)) ? this.Titulo:filme.Titulo;
        filme.Genero = (!string.IsNullOrWhiteSpace(this.Genero)) ? this.Genero : filme.Genero;
        filme.Duracao = (this.Duracao is not null) ? (int)this.Duracao : filme.Duracao;
    }
}
