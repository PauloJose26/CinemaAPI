using CinemaAPI.Models;
using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Data.Dtos;

public class UpdateFilmeDto
{
    [Required(ErrorMessage = "O Título do filme é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O Genero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O Genero não pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "A Duração do filme é obrigatório")]
    [Range(70, 600, ErrorMessage = "A Duração do filme deve ter entre 70 e 600 minutos")]
    public int Duracao { get; set; }

    public UpdateFilmeDto(string titulo, string genero, int duracao)
    {
        this.Titulo = titulo;
        this.Genero = genero;
        this.Duracao = duracao;
    }

    public static UpdateFilmeDto ConverterParaUpdateFilme(Filme filme) => new(filme.Titulo, filme.Genero, filme.Duracao);

    public void AtualizarFilme(Filme filme)
    {
        filme.Titulo = this.Titulo;
        filme.Genero = this.Genero;
        filme.Duracao = this.Duracao;
    }
}
