using System.ComponentModel.DataAnnotations;
using CinemaAPI.Models;


namespace CinemaAPI.Data.Dtos;

public class UpdateFilmeDto
{
    [Required(ErrorMessage = "O campo título do Filme é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo genero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O campo genero não pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O campo duração do filme é obrigatório")]
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
