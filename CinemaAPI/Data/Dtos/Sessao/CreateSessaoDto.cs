using CinemaAPI.Models;
using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Data.Dtos;

public class CreateSessaoDto
{
    [Required]
    public int FilmeId { get; set; }

    public Sessao ConverterParaSessao() => new(FilmeId);
}
