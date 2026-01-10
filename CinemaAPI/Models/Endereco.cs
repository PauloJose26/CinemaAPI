using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Logradouro { get; set; }

    public int? Numero { get; set; }

    public Endereco(string logradouro, int? numero)
    {
        this.Logradouro = logradouro;
        this.Numero = numero;
    }
}
