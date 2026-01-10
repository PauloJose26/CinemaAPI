using CinemaAPI.Models;
using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Data.Dtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O campo nome do Cinema é obrigatório")]
    public string Nome { get; set; }

    public Cinema ConverterCinema() => new(this.Nome);
}
