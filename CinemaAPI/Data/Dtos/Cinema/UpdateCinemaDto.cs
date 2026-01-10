using CinemaAPI.Models;
using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Data.Dtos;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo nome do Cinema é obrigatório")]
    public string Nome { get; set; }

    public UpdateCinemaDto(string nome)
    {
        this.Nome = nome;
    }

    public static UpdateCinemaDto ConverterParaUpdateCinema(Cinema cinema) => new(cinema.Nome);

    public void AtualizarCinema(Cinema cinema)
    {
        cinema.Nome = this.Nome;
    }
}
