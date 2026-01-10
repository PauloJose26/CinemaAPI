using CinemaAPI.Models;
using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Data.Dtos;

public class CreateFilmeDto
{
    [Required(ErrorMessage = "O campo título do Filme é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo genero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O campo genero não pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O campo duração do filme é obrigatório")]
    [Range(70, 600, ErrorMessage = "A Duração do filme deve ter entre 70 e 600 minutos")]
    public int Duracao { get; set; }

    public Filme ConverterFilme() => new(this.Titulo, this.Genero, this.Duracao);
}
