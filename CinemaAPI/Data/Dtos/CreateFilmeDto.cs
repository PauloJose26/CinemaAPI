using CinemaAPI.Models;
using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Data.Dtos;

public class CreateFilmeDto
{
    [Required(ErrorMessage = "O Título do filme é necessário")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O Genero do filme é necessário")]
    [MaxLength(50, ErrorMessage = "O Genero não pode exceder 50 caracteres")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A Duração do filme é necessário")]
    [Range(70, 600, ErrorMessage = "A Duração do filme deve ter entre 70 e 600 minutos")]
    public int Duracao { get; set; }

    public Filme ConverterFilme()
    {
        return new(this.Titulo, this.Genero, this.Duracao);
    }
}
