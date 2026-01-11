using CinemaAPI.Models;
using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Data.Dtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O campo nome do Cinema é obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo enderecoid do Cinema é obrigatório")]
    public int EnderecoId { get; set; }

    public Cinema ConverterParaCinema() => new(this.Nome, this.EnderecoId);
}
