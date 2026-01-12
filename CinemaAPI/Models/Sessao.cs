using System.ComponentModel.DataAnnotations;


namespace CinemaAPI.Models;

public class Sessao
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public int FilmeId { get; set; }
    public virtual Filme Filme { get; set; }

    public Sessao(int filmeId)
    {
        FilmeId = filmeId;
    }
}
