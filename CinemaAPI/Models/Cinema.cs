using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }

    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }

    public Cinema(string nome)
    {
        this.Nome = nome;
    }

    public Cinema(string nome, int enderecoId)
    {
        this.Nome = nome;
        this.EnderecoId = enderecoId;
    }
}
