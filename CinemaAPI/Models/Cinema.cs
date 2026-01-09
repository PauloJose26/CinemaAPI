using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }

    public Cinema(string nome)
    {
        this.Nome = nome;
    }
}
