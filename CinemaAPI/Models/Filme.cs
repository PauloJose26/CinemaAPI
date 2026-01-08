using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Titulo { get; set; }
    [Required]
    [MaxLength(50)]
    public string Genero { get; set; }
    [Required]
    [Range(70, 600)]
    public int Duracao { get; set; }

    public Filme(string titulo, string genero, int duracao)
    {
        this.Titulo = titulo;
        this.Genero = genero;
        this.Duracao = duracao;
    }
}
